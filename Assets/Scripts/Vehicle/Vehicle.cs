using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    private Rigidbody _rb;
    private WheelCollider[] _wheels;

    [SerializeField] private VehicleType vehicleType;

    [Header("Specifications")] [SerializeField]
    private bool canBoost = false;

    [SerializeField] private float motorTorque = 675;
    [SerializeField] private float brakeForce = 1500.0f;
    [SerializeField] private float maxHealth = 1000;
    [SerializeField] private float maxFuel = 100;
    [SerializeField] private float durability = 150;
    [SerializeField] private float maxBoost = 10f;
    [SerializeField] private float boostForce = 5000;
    [SerializeField] private float skillCooldown = 3.75f;
    [SerializeField] private float skillPower = 1.45f;
    [SerializeField] private int ammo = 0;
    [SerializeField] private float boostRegen = 0.2f;
    [SerializeField] private float idlingFuelConsumption = 0.5F;
    [SerializeField] private float gasFuelConsumption = 1.25F;


    [Header("Geçici Veriler")] [SerializeField]
    private float boost;

    [SerializeField] private float health;
    [SerializeField] private float fuel;
    [SerializeField] private float steering;
    [SerializeField] private float throttle;
    [SerializeField] private float speed;
    [SerializeField] private float lastSpeed;
    [SerializeField] private bool isGrounded;

    [SerializeField] private int lastGroundCheck;
    [SerializeField] private bool handbrake;


    public static float HorizontalInput;
    public static bool Gas;
    public static bool Brake;
    public static bool BoostParam;
    public static float RotationInput;

    private float _timer;
    private float _realHorizontalInput;
    private float _lastSkillTime;

    private float downforce = 7f;
    private float steerSpeed = 0.25f;
    private float rotationSpeed = 65F;
    private float steerAngle = 30.0f;

    [Header("Wheels")] [SerializeField] private WheelCollider[] driveWheel;
    [SerializeField] private WheelCollider[] turnWheel;


    [SerializeField] private Transform centerOfMass;
    [Header("Particles")] [SerializeField] private ParticleSystem[] gasParticles;
    [SerializeField] private ParticleSystem[] boostParticles;
    [SerializeField] private ParticleSystem[] explosionParticles;

    [Header("Boost Sound")] [SerializeField]
    private AudioClip boostClip;

    [SerializeField] private AudioSource boostSource;

    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;

    public bool IsDead => health <= 0;

    public bool FuelEmpty => fuel <= 0;

    public bool CanMove => !IsDead && !FuelEmpty;
    public bool Handbrake => handbrake;
    public float Speed => speed;

    public bool CanUseSkill => (_timer >= _lastSkillTime) && CanMove;

    public float SkillTimer => _lastSkillTime - _timer;
    public float HealthPercentage => health / maxHealth;
    public float BoostPercentage => boost / maxBoost;
    public float FuelPercentage => fuel / maxFuel;
    public VehicleType VehicleType => vehicleType;

    public virtual void Start()
    {
        if (boostClip != null)
        {
            boostSource.clip = boostClip;
        }

        _startPosition = transform.position;
        health = maxHealth;
        boost = maxBoost;
        fuel = maxFuel;
        boost = maxBoost;

        _rb = GetComponent<Rigidbody>();

        if (_rb != null && centerOfMass != null)
        {
            _rb.centerOfMass = centerOfMass.localPosition;
        }

        _wheels = GetComponentsInChildren<WheelCollider>();

        foreach (var wheel in _wheels)
        {
            wheel.motorTorque = 0.0001f;
        }
    }

    private void Update()
    {
        foreach (var gasParticle in gasParticles)
        {
            gasParticle.Play();
            var em = gasParticle.emission;
            em.rateOverTime = handbrake
                ? 0
                : Mathf.Lerp(em.rateOverTime.constant, Mathf.Clamp(150.0f * throttle, 30.0f, 100.0f), 0.1f);
        }

        if (canBoost && !BoostParam)
        {
            boost += Time.deltaTime * boostRegen;
            if (boost > maxBoost)
            {
                boost = maxBoost;
            }
        }

        _timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (GameController.DebugMode)
        {
            GameController.GetDebugInputs();
        }

        GetHorizontalInput();
        GetHandleValues();
        HandleWheels();
        HandleMotor();
        HandleRotate();
        Boost();
        DownForce();
    }


    private void HandleRotate()
    {
        if (!IsGrounded)
        {
            transform.Rotate(Vector3.Lerp(new Vector3(RotationInput, 0, 0) * Time.fixedDeltaTime,
                new Vector3(RotationInput * rotationSpeed, 0, 0) * Time.fixedDeltaTime, 1.0F));
        }
    }

    private void DownForce()
    {
        _rb.AddForce(-transform.up * (speed * downforce));
    }

    private void Boost()
    {
        if (CanMove && BoostParam && canBoost && boost > 0f)
        {
            _rb.AddForce(transform.forward * boostForce);

            boost -= Time.fixedDeltaTime;
            if (boost < 0f)
            {
                boost = 0f;
            }

            if (boostParticles.Length > 0 /*&& !boostParticles[0].isPlaying*/)
            {
                foreach (var boostParticle in boostParticles)
                {
                    boostParticle.Play();
                }
            }

            if (boostSource != null && !boostSource.isPlaying)
            {
                boostSource.Play();
            }
        }
        else
        {
            if (boostParticles.Length > 0 && boostParticles[0].isPlaying)
            {
                foreach (ParticleSystem boostParticle in boostParticles)
                {
                    boostParticle.Stop();
                }
            }

            if (boostSource != null && boostSource.isPlaying)
            {
                boostSource.Stop();
            }
        }
    }

    public void UseSkill()
    {
        if (CanUseSkill)
        {
            switch (VehicleType)
            {
                case VehicleType.KnightRider:
                    Jump();
                    break;
                case VehicleType.OldSedanVip:
                    AddHeal();
                    break;
            }

            _lastSkillTime = _timer + skillCooldown;
        }
    }

    private void AddHeal()
    {
        health += skillPower / 2;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        fuel += skillPower / 3;
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }

    private void Jump()
    {
        if (!IsGrounded)
            return;

        _rb.velocity += transform.up * skillPower;
    }

    private void HandleWheels()
    {
        foreach (WheelCollider wheel in turnWheel)
        {
            wheel.steerAngle = Mathf.Lerp(wheel.steerAngle, steering, steerSpeed);
        }

        foreach (WheelCollider wheel in _wheels)
        {
            wheel.brakeTorque = 0;
        }
    }

    private void HandleMotor()
    {
        if (handbrake)
        {
            foreach (var wheel in _wheels)
            {
                wheel.motorTorque = 0.0001f;
                wheel.brakeTorque = brakeForce;
            }
        }
        else if (Mathf.Abs(speed) < 4 || Mathf.Sign(speed) == Mathf.Sign(throttle))
        {
            if (CanMove)
            {
                foreach (var wheel in driveWheel)
                {
                    wheel.motorTorque = throttle * motorTorque / driveWheel.Length;
                }

                FuelConsumption();
            }
            else
            {
                handbrake = true;
            }
        }
        else
        {
            foreach (var wheel in _wheels)
            {
                wheel.motorTorque = 0.0001f;
                wheel.brakeTorque = Math.Abs(throttle) * brakeForce;
            }
        }
    }

    public void AddFuel(float f)
    {
        fuel += f;
        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }

        handbrake = false;
    }

    private void FuelConsumption()
    {
        var consumption = idlingFuelConsumption;
        if (Math.Abs(throttle) >= 0.1)
        {
            consumption = gasFuelConsumption;
        }

        fuel -= consumption * Time.fixedDeltaTime;
    }

    private void GetHorizontalInput()
    {
        if (HorizontalInput > 0)
        {
            _realHorizontalInput += 0.075F;
            if (_realHorizontalInput > 1.0F)
            {
                _realHorizontalInput = 1.0F;
            }
        }
        else if (HorizontalInput < 0)
        {
            _realHorizontalInput -= 0.075F;
            if (_realHorizontalInput < -1.0F)
            {
                _realHorizontalInput = -1.0F;
            }
        }
        else
        {
            _realHorizontalInput = 0.0F;
        }
    }

    private void GetHandleValues()
    {
        speed = transform.InverseTransformDirection(_rb.velocity).z * 3.6f;
        throttle = (Gas ? 1.0F : 0.0F) - (Brake ? 1.0F : 0.0F);
        steering = _realHorizontalInput * steerAngle;
    }

    public void ToggleHandbrake(bool h)
    {
        handbrake = h;
    }


    public bool IsGrounded
    {
        get
        {
            if (lastGroundCheck == Time.frameCount)
                return isGrounded;

            lastGroundCheck = Time.frameCount;
            isGrounded = true;
            foreach (var wheel in _wheels)
            {
                if (!wheel.gameObject.activeSelf || !wheel.isGrounded)
                    isGrounded = false;
            }

            return isGrounded;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        lastSpeed = speed;
    }

    private void OnCollisionExit(Collision other)
    {
        var currentSpeed = speed;
        var damage = Math.Abs(currentSpeed - lastSpeed);
        if (damage > 3.5F)
        {
            Hit(damage);
        }
    }

    private void Hit(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            ExplosionEffect();
            health = 0;
        }
    }

    private void ExplosionEffect()
    {
        foreach (var particle in explosionParticles)
        {
            particle.Play();
        }
    }
}