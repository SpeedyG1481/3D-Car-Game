using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class Entity : MonoBehaviour
{
    public float speed = 2.0f;
    public float jump = 1.0f;
    public float detectorRange = 50.0f;
    public bool IsGrounded;
    private float _gravityValue = -9.81f;

    private float _verticalSpeed = 0;

    private Animator _animator;
    protected float distance;
    protected Vehicle _target;
    protected CharacterController _characterController;

    public Animator Animator => _animator;
    public CharacterController CharacterController => _characterController;

    public Vector3 Velocity
    {
        get => _velocity;
        set
         => _velocity = value;

    }

    private Vector3 _velocity;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }


    public virtual void Update()
    {
        FindTarget();
        LocateTarget();
        Move();
        // Debug.Log(distance);
    }

    private void LocateTarget()
    {
        
        if (_target != null)
        {
            var targetDirection = _target.transform.position - transform.position;
            var singleStep = speed * Time.deltaTime;

            var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            // Bir saniyede alacağı yol!
            Debug.DrawRay(transform.position, newDirection * speed, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
            _velocity = new Vector3(newDirection.x, 0, newDirection.z);
        }
        else
        {
            _velocity = Vector3.zero;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void FindTarget()
    {
        var vehicle = FindObjectOfType<Vehicle>();

        if (vehicle != null)
        {
            distance = Vector3.Distance(transform.position, vehicle.transform.position);

            if (distance <= detectorRange)
            {
                _target = vehicle;
            }
            else
            {
                _target = null;
            }
        }
        else
        {
            _target = null;
        }

        Debug.Log(_target);
    }


    public virtual void Move()
    {
        _characterController.Move(_velocity * (speed * Time.deltaTime));
        _velocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
        _animator.SetBool("Walk", !(Math.Abs(_characterController.velocity.magnitude) < 0.2F));
    }
    public void damage(float amount)
    {
        //car will be damaged
        _target.Hit(amount);
    }
}