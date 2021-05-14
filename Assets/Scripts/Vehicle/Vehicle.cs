using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{
    private float _steering;
    private float _throttle;

    private bool _isGrounded = false;
    public bool boosting = false;
    public bool jumping = false;

    private int _lastGroundCheck = 0;


    private Vector3 _spawnPosition;
    private Quaternion _spawnRotation;

    private Rigidbody _rb;
    private WheelCollider[] _wheels;

    [Header("Specifications")] [SerializeField]
    private float maxHealth = 1000;

    [SerializeField] private float durability = 150;

    private float health;


    [Header("Inputs")] [SerializeField] private string throttleInput = "Throttle";
    [SerializeField] private string brakeInput = "Brake";
    [SerializeField] private string jumpInput = "Jump";
    [SerializeField] private string boostInput = "Boost";
    [SerializeField] private string turnInput = "Horizontal";

    [Header("Wheels")] [SerializeField] private WheelCollider[] driveWheel;
    [SerializeField] private WheelCollider[] turnWheel;

    [Header("Behaviour")] [SerializeField] private float motorTorque = 350;
    [Range(2, 16)] [SerializeField] private float diffGearing = 4.0f;
    [SerializeField] private float brakeForce = 1500.0f;
    [Range(0f, 50.0f)] [SerializeField] private float steerAngle = 30.0f;
    [Range(0.001f, 1.0f)] [SerializeField] private float steerSpeed = 0.2f;
    [Range(1f, 2.5f)] [SerializeField] private float jumpVel = 1.45f;
    [Range(0.0f, 2f)] [SerializeField] private float driftIntensity = 1f;
    [SerializeField] private Transform centerOfMass;
    [Range(0.5f, 10f)] [SerializeField] private float downforce = 1.0f;
    [SerializeField] private bool handbrake;
    public bool Handbrake => handbrake;
    [SerializeField] private float speed = 0.0f;
    public float Speed => speed;
    [Header("Particles")] [SerializeField] ParticleSystem[] gasParticles;
    [Header("Boost")] [HideInInspector] public bool allowBoost = true;
    [SerializeField] private float maxBoost = 10f;
    [SerializeField] private float boost = 10f;
    [Range(0f, 1f)] [SerializeField] private float boostRegen = 0.2f;
    [SerializeField] private float boostForce = 5000;
    [SerializeField] private AnimationCurve turnInputCurve = AnimationCurve.Linear(-1.0f, -1.0f, 1.0f, 1.0f);
    [SerializeField] private ParticleSystem[] boostParticles;
    [SerializeField] private AudioClip boostClip;
    [SerializeField] private AudioSource boostSource;

    public virtual void Start()
    {
        if (boostClip != null)
        {
            boostSource.clip = boostClip;
        }

        health = maxHealth;


        boost = maxBoost;

        _rb = GetComponent<Rigidbody>();
        _spawnPosition = transform.position;
        _spawnRotation = transform.rotation;

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

    void Update()
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
            boost += Time.deltaTime * boostRegen;
            if (boost > maxBoost)
            {
                boost = maxBoost;
            }
        }
    }

    void FixedUpdate()
    {
        HandleVehicle();
        HandleWheels();
        HandleMotor();
        Jump();
        Boost();
        //HandleDrift();
        DownForce();
    }

    private void DownForce()
    {
        _rb.AddForce(-transform.up * (speed * downforce));
    }

    private void Boost()
    {
        if (boosting && allowBoost && boost > 0.1f)
        {
            _rb.AddForce(transform.forward * boostForce);

            boost -= Time.fixedDeltaTime;
            if (boost < 0f)
            {
                boost = 0f;
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
            foreach (WheelCollider wheel in _wheels)
            {
                wheel.motorTorque = 0.0001f;
                wheel.brakeTorque = brakeForce;
            }
        }
        else if (Mathf.Abs(speed) < 4 || Mathf.Sign(speed) == Mathf.Sign(_throttle))
        {
            foreach (WheelCollider wheel in driveWheel)
            {
                wheel.motorTorque = _throttle * motorTorque * diffGearing / driveWheel.Length;
            }
        }
        else
        {
            foreach (WheelCollider wheel in _wheels)
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

    public void ResetPos()
    {
        transform.position = _spawnPosition;
        transform.rotation = _spawnRotation;

        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
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
        var velocity = speed / 3 * 2;
        float otherVelocity = 0;

        if (other.rigidbody != null)
        {
            otherVelocity = transform.InverseTransformDirection(other.rigidbody.velocity).z * 3.6f;
        }

        var absVelocity = Math.Abs(velocity - otherVelocity);

        Debug.Log("Other: " + otherVelocity + " - Our: " + velocity + " -> " + absVelocity);
    }
}