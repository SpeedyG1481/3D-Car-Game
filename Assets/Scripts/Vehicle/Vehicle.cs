using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    private bool _isGrounded = false;
    public bool boosting = false;
    public bool jumping = false;

    private int _lastGroundCheck = 0;

    private Rigidbody _rb;
    private WheelCollider[] _wheels;

    [Header("Specifications")] [SerializeField]
    private float maxHealth = 1000;

    [SerializeField] private float maxFuel = 100;
    [Range(0.0f, 2.5f)] [SerializeField] private float idlingFuelConsumption = 0.1F;
    [Range(0.1f, 5.0f)] [SerializeField] private float gasFuelConsumption = 0.25F;
    [SerializeField] private float motorTorque = 675;
    [SerializeField] private float brakeForce = 1500.0f;
    [Range(0f, 50.0f)] [SerializeField] private float steerAngle = 30.0f;
    [Range(1f, 2.5f)] [SerializeField] private float jumpVel = 1.45f;
    [SerializeField] private float durability = 150;
    [SerializeField] private float maxBoost = 10f;

    private float _boost;
    private float _health;
    private float _fuel;
    private float _steering;
    private float _throttle;


    [Header("Inputs")] [SerializeField] private string throttleInput = "Throttle";
    [SerializeField] private string brakeInput = "Brake";
    [SerializeField] private string jumpInput = "Jump";
    [SerializeField] private string boostInput = "Boost";
    [SerializeField] private string turnInput = "Horizontal";

    [Header("Wheels")] [SerializeField] private WheelCollider[] driveWheel;
    [SerializeField] private WheelCollider[] turnWheel;

    private float steerSpeed = 0.25f;

    [SerializeField] private Transform centerOfMass;
    [Range(0.5f, 10f)] [SerializeField] private float downforce = 1.0f;
    [SerializeField] private bool handbrake;
    public bool Handbrake => handbrake;
    [SerializeField] private float speed = 0.0f;
    private float _lastSpeed;
    public float Speed => speed;
    [Header("Particles")] [SerializeField] ParticleSystem[] gasParticles;
    [Header("Boost")] [HideInInspector] public bool allowBoost = true;
    [Range(0f, 1f)] [SerializeField] private float boostRegen = 0.2f;
    [SerializeField] private float boostForce = 5000;
    [SerializeField] private AnimationCurve turnInputCurve = AnimationCurve.Linear(-1.0f, -1.0f, 1.0f, 1.0f);
    [SerializeField] private ParticleSystem[] boostParticles;
    [SerializeField] private AudioClip boostClip;
    [SerializeField] private AudioSource boostSource;

    public bool IsDead => _health <= 0;

    public virtual void Start()
    {
        if (boostClip != null)
        {
            boostSource.clip = boostClip;
        }

        _health = maxHealth;
        _boost = maxBoost;
        _fuel = maxFuel;
        _boost = maxBoost;

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
                : Mathf.Lerp(em.rateOverTime.constant, Mathf.Clamp(150.0f * _throttle, 30.0f, 100.0f), 0.1f);
        }

        if (allowBoost)
        {
            _boost += Time.deltaTime * boostRegen;
            if (_boost > maxBoost)
            {
                _boost = maxBoost;
            }
        }
    }

    private void FixedUpdate()
    {
        HandleVehicle();
        HandleWheels();
        HandleMotor();
        Jump();
        Boost();
        DownForce();
    }

    private void DownForce()
    {
        _rb.AddForce(-transform.up * (speed * downforce));
    }

    private void Boost()
    {
        if (boosting && allowBoost && _boost > 0.1f)
        {
            _rb.AddForce(transform.forward * boostForce);

            _boost -= Time.fixedDeltaTime;
            if (_boost < 0f)
            {
                _boost = 0f;
            }

            if (boostParticles.Length > 0 && !boostParticles[0].isPlaying)
            {
                foreach (ParticleSystem boostParticle in boostParticles)
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

    private void Jump()
    {
        if (jumping)
        {
            if (!IsGrounded)
                return;

            _rb.velocity += transform.up * jumpVel;
        }
    }

    private void HandleWheels()
    {
        foreach (WheelCollider wheel in turnWheel)
        {
            wheel.steerAngle = Mathf.Lerp(wheel.steerAngle, _steering, steerSpeed);
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
        else if (Mathf.Abs(speed) < 4 || Mathf.Sign(speed) == Mathf.Sign(_throttle))
        {
            foreach (var wheel in driveWheel)
            {
                wheel.motorTorque = _throttle * motorTorque / driveWheel.Length;
            }
        }
        else
        {
            foreach (var wheel in _wheels)
            {
                wheel.brakeTorque = Mathf.Abs(_throttle) * brakeForce;
            }
        }
    }

    private void HandleVehicle()
    {
        speed = transform.InverseTransformDirection(_rb.velocity).z * 3.6f;


        if (throttleInput != "" && throttleInput != null)
        {
            _throttle = GetInput(throttleInput) - GetInput(brakeInput);
        }

        boosting = (GetInput(boostInput) > 0.5f);
        _steering = turnInputCurve.Evaluate(GetInput(turnInput)) * steerAngle;
        jumping = GetInput(jumpInput) != 0;
    }

    public void ToggleHandbrake(bool h)
    {
        handbrake = h;
    }


    private float GetInput(string input)
    {
        switch (input)
        {
            case "Throttle":
                return Input.GetAxis("Vertical");
            case "Brake":
                return Input.GetKey(KeyCode.Space) ? 1.0F : 0F;
            case "Boost":
                return Input.GetAxis("Fire1");
            case "Jump":
                return Input.GetAxis("Fire2");
            case "Horizontal":
                return Input.GetAxis("Horizontal");
        }

        return 0.0F;
    }


    public bool IsGrounded
    {
        get
        {
            if (_lastGroundCheck == Time.frameCount)
                return _isGrounded;

            _lastGroundCheck = Time.frameCount;
            _isGrounded = true;
            foreach (var wheel in _wheels)
            {
                if (!wheel.gameObject.activeSelf || !wheel.isGrounded)
                    _isGrounded = false;
            }

            return _isGrounded;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        _lastSpeed = speed;
    }

    private void OnCollisionExit(Collision other)
    {
        var currentSpeed = speed;
        var lastSpeed = _lastSpeed;

        var damage = Math.Abs(currentSpeed - lastSpeed);
        Hit(damage);
        Debug.Log("Exit Last Speed: " + lastSpeed + " - Current: " + currentSpeed + " -> Damage: " + damage);
    }

    public void Hit(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
    }
}