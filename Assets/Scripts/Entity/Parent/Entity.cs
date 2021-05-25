using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Entity : MonoBehaviour
{
    private Vehicle _player;
    private Rigidbody _rigidbody;
    private Animator _animator;

    public float maxHealth = 100;
    public float removeTime = 10;

    private float _health;
    protected static bool IsChasing, IsJumping, IsShooting;

    public Rigidbody Rigidbody => _rigidbody;
    public Animator Animator => _animator;

    private float _timer = 0;
    private float _deadTimer = 0;

    private bool _deathAnimation = false;


    public float Health => _health;
    public bool IsDead => _health <= 0;

    public virtual void Start()
    {
        _health = maxHealth;
        _player = FindTarget();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        Walk();
        if (IsDead)
            Death();
        _timer += Time.deltaTime;
    }

    private void Walk()
    {
        _animator.SetBool("Walk", _rigidbody.velocity.magnitude != 0 && !IsDead);
    }

    private void Death()
    {
        if (!_deathAnimation)
        {
            _deadTimer = _timer + removeTime;
            _deathAnimation = true;
            _animator.SetTrigger("Death");
        }

        if (_deadTimer > 0 && _timer > _deadTimer)
        {
            if (isActiveAndEnabled)
            {
                DeleteObject();
            }

            _deadTimer = -1F;
        }
    }

    private void DeleteObject()
    {
        Destroy(gameObject);
    }

    private Vehicle FindTarget()
    {
        Vehicle vehicle = null;
        foreach (var v in FindObjectsOfType<Vehicle>())
        {
            if (v.isActiveAndEnabled)
            {
                vehicle = v;
                break;
            }
        }

        return vehicle;
    }

    public Vehicle Player
    {
        get => _player;
        set => _player = value;
    }


    public float Distance()
    {
        var dist = Vector3.Distance(_player.transform.position, transform.position);

        return dist;
    }


    public void Chase(float moveSpeed)
    {
        transform.LookAt(_player.transform);
        _rigidbody.velocity = transform.forward * moveSpeed;
        IsChasing = true;
    }

    public void Jump(float jumpAmount)
    {
        _rigidbody.velocity += Vector3.up * jumpAmount;
        IsJumping = true;
        _animator.SetTrigger("Jump Attack");
    }

    void Shooting()
    {
        IsShooting = true;
    }

    public virtual void Hit(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
    }
}