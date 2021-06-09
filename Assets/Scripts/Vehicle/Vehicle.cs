using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    private Rigidbody _rb;
    private WheelCollider[] _wheels;
    private List<Light> _brakeLights;

    [SerializeField] private VehicleType vehicleType;
    [SerializeField] private Vehicles vehicleEnum;
    [SerializeField] private Transform centerOfMass;

    [Header("Specifications")] [SerializeField]
    private float motorTorque = 675;

    [SerializeField] private float brakeForce = 1500.0f;
    [SerializeField] private float maxHealth = 1000;
    [SerializeField] private float maxFuel = 100;
    [SerializeField] private float durability = 150;
    [SerializeField] private float maxBoost = 10f;
    [SerializeField] private float boostForce = 5000;
    [SerializeField] private float boostRegen = 0.2f;
    [SerializeField] private float idlingFuelConsumption = 0.5F;
    [SerializeField] private float gasFuelConsumption = 1.25F;
    [SerializeField] private float wheelStiffness = 1.8F;
    [SerializeField] private float skillCooldown = 3.75f;
    [SerializeField] private float skillPower = 1.45f;

    [SerializeField] private int ammo = 0;
    //[SerializeField] private int maxSpeed = 50;


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
    [SerializeField] private float engineRpm = 0.0f;
    [SerializeField] private int currentGear = 0;


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

    [Header("Wheel & Particles")] [SerializeField]
    private WheelCollider[] turnWheel;


    [SerializeField] private ParticleSystem[] gasParticles;
    [SerializeField] private ParticleSystem[] boostParticles;


    private AudioSource _boostSource;
    private AudioSource _engineSource;
    private AudioSource _damageSource;

    [Header("Clip Settings")] [SerializeField]
    private AudioClip boostClip;

    [SerializeField] private AudioClip rolling;
    [SerializeField] private AudioClip stopping;
    [SerializeField] private AudioClip damageSound;


    [Header("Engine & Gear")] private float _maxEngineRpm = 6000.0f;
    private float _minEngineRpm = 1500.0f;

    private float[] _gearRatio =
    {
        4.25F,
        3.25F,
        2.25F,
        1.25F,
        0.5F
    };

    private bool _canUseGoTo10 = true;
    private bool _canUseDoubleComponent = true;

    public bool CanUseGoTo10
    {
        get => _canUseGoTo10;
        set => _canUseGoTo10 = value;
    } 
    
    public bool CanUseDoubleComponent
    {
        get => _canUseDoubleComponent;
        set => _canUseDoubleComponent = value;
    }


    private Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;

    public bool IsDead => health <= 0;

    public bool FuelEmpty => fuel <= 0;

    public bool CanMove => !IsDead && !FuelEmpty;
    public bool Handbrake => handbrake;
    public float Speed => speed;

    public bool CanUseSkill => _timer >= _lastSkillTime && CanMove;

    public float SkillTimer => _lastSkillTime - _timer;
    public float HealthPercentage => health / maxHealth;
    public float BoostPercentage => boost / maxBoost;
    public float FuelPercentage => fuel / maxFuel;
    public float MaxFuel => maxFuel;
    public float MaxHeal => maxHealth;
    public VehicleType VehicleType => vehicleType;
    public Vehicles VehicleEnum => vehicleEnum;

    public Transform CenterOfMass => centerOfMass;


    public virtual void Start()
    {
        _startPosition = transform.position;
        _boostSource = gameObject.AddComponent<AudioSource>();
        _engineSource = gameObject.AddComponent<AudioSource>();
        _damageSource = gameObject.AddComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _brakeLights = new List<Light>();
        var lights = GetComponentsInChildren<Light>();
        foreach (var light in lights)
        {
            if (light.type == LightType.Point && light.gameObject.name.Contains("Brake"))
            {
                _brakeLights.Add(light);
            }
        }

        if (boostClip != null)
        {
            _boostSource.clip = boostClip;
        }

        if (_rb != null && centerOfMass != null)
        {
            _rb.centerOfMass = centerOfMass.localPosition;
        }


        _wheels = GetComponentsInChildren<WheelCollider>();
        PrepareCar();
    }

    private void Update()
    {
        GasParticles();
        BoostRegenerator();
        EngineSound();
        TimerController();
        BrakeLights();
    }


    private void BrakeLights()
    {
        float intensity = 2;
        if (Brake)
        {
            intensity = 5;
        }

        foreach (var l in _brakeLights)
        {
            l.intensity = intensity;
        }
    }

    private void GasParticles()
    {
        foreach (var gasParticle in gasParticles)
        {
            gasParticle.Play();
            var em = gasParticle.emission;
            em.rateOverTime = handbrake
                ? 0
                : Mathf.Lerp(em.rateOverTime.constant, Mathf.Clamp(150.0f * throttle, 30.0f, 100.0f), 0.1f);
        }
    }

    private void BoostRegenerator()
    {
        if (!BoostParam)
        {
            boost += Time.deltaTime * boostRegen;
            if (boost > maxBoost)
            {
                boost = maxBoost;
            }
        }
    }

    private void TimerController()
    {
        _timer += Time.deltaTime;
    }

    private void EngineSound()
    {
        _engineSource.volume = GameController.GetSfxVolume;
        if (Handbrake && _engineSource.clip == rolling)
        {
            _engineSource.clip = stopping;
            _engineSource.Play();
        }

        if (!Handbrake && !_engineSource.isPlaying)
        {
            _engineSource.clip = rolling;
            _engineSource.Play();
        }

        if (_engineSource.clip == rolling)
        {
            engineRpm = (_wheels[0].rpm + _wheels[1].rpm) / 2 * _gearRatio[currentGear] * 10;
            ShiftGears();

            _engineSource.pitch = Mathf.Abs(engineRpm / _maxEngineRpm) + 1.0f;
            if (_engineSource.pitch > 2.0f)
            {
                _engineSource.pitch = 2.0f;
            }
        }
    }

    private void ShiftGears()
    {
        if (engineRpm >= _maxEngineRpm)
        {
            var appropriateGear = currentGear;

            for (var i = 0; i < _gearRatio.Length; i++)
            {
                if (_wheels[0].rpm * _gearRatio[i] * 10 < _maxEngineRpm)
                {
                    appropriateGear = i;
                    break;
                }
            }

            currentGear = appropriateGear;
        }

        if (engineRpm <= _minEngineRpm)
        {
            var appropriateGear = currentGear;

            for (var j = _gearRatio.Length - 1; j >= 0; j--)
            {
                if (_wheels[0].rpm * _gearRatio[j] * 10 > _minEngineRpm)
                {
                    appropriateGear = j;
                    break;
                }
            }

            currentGear = appropriateGear;
        }
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
        if (CanMove && BoostParam && boost > 0f)
        {
            _rb.AddForce(transform.forward * boostForce);
            _boostSource.volume = GameController.GetSfxVolume;

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

            if (_boostSource != null && !_boostSource.isPlaying)
            {
                _boostSource.Play();
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

            if (_boostSource != null && _boostSource.isPlaying)
            {
                _boostSource.Stop();
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

    public void AddHeal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
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
        foreach (var wheel in turnWheel)
        {
            wheel.steerAngle = Mathf.Lerp(wheel.steerAngle, steering, steerSpeed);
        }

        foreach (var wheel in _wheels)
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
                foreach (var wheel in _wheels)
                {
                    var gear = _gearRatio[currentGear];
                    if (gear > 2.0F)
                    {
                        gear /= 2;
                    }

                    var realMotorTorque = throttle * gear * motorTorque / 4.0f;
                    wheel.motorTorque = realMotorTorque;
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
        if (!other.gameObject.CompareTag("Enemy"))
        {
            lastSpeed = speed;
            _rb.velocity = -transform.forward * 3.5F;
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Enemy"))
        {
            var damage = Math.Abs(speed - lastSpeed);
            Hit(damage, DamageType.Wall);
        }
    }

    public void Hit(float damage, DamageType type)
    {
        if (damage < 0)
            return;

        var realDamage = (float) (damage - durability);
        if (realDamage < 0)
            realDamage = 0;

        if (damageSound != null && type == DamageType.Wall)
        {
            _damageSource.volume = GameController.GetSfxVolume;
            _damageSource.PlayOneShot(damageSound, GameController.GetSfxVolume);
        }

        health -= realDamage;
        if (health < 0)
        {
            health = 0;
        }
    }

    private void PrepareCar()
    {
        var partUpgrade = PartUpgrade.GetPartUpgrade();
        idlingFuelConsumption -= partUpgrade.FuelConsumptionIdle;
        gasFuelConsumption -= partUpgrade.FuelConsumptionGas;
        _rb.mass -= partUpgrade.Mass;
        motorTorque += partUpgrade.Engine;
        maxHealth += partUpgrade.Health;
        maxBoost += partUpgrade.BoostFuel;
        boostForce += partUpgrade.BoostPower;
        boostRegen += partUpgrade.BoostRegen;
        maxFuel += partUpgrade.Fuel;
        brakeForce += partUpgrade.Brake;
        durability += partUpgrade.Durability;
        skillPower += partUpgrade.AbilityPower;
        skillCooldown -= partUpgrade.AbilityTime;
        ammo += partUpgrade.Ammo;

        var gun = GetComponentInChildren<Gun>();
        if (gun != null)
        {
            gun.Ammo = ammo;
        }

        foreach (var wheel in _wheels)
        {
            var forward = wheel.forwardFriction;
            var sideways = wheel.sidewaysFriction;
            forward.stiffness = wheelStiffness + partUpgrade.WheelStiffness;
            sideways.stiffness = wheelStiffness + partUpgrade.WheelStiffness;

            wheel.sidewaysFriction = sideways;
            wheel.forwardFriction = forward;

            wheel.motorTorque = 0.0001f;
        }

        health = maxHealth;
        boost = maxBoost;
        fuel = maxFuel;
        boost = maxBoost;
    }

    //DEAD SCREEN KARAKTER ÖLDÜĞÜNDE AÇILACAK VE RESET İÇERİSİNDE BELİRTİLEN BOOL VALUE İLE AÇILIMI KONTROL EDİLECEK.
    //ÖLÜM OLDUĞUNDA TİMESCALE YADA FARKLI BİR YÖNTEM İLE OYUN DURACAK.
    
    public void DoubleComponent()
    {
        //Kullanıcının level içerisinde topladığı nesneler tutulacak ve 2x yapılacak kullanıcıya aktarılacak. (1x olarak aktaracağız toplam 2 olacak)
    }

    public void Reset()
    {
        //Menü kontrolü için kullanılan bool value oluşturulacak ve burada ters edilecek.
    }
}