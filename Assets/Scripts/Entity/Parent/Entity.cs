using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator)),]
public class Entity : MonoBehaviour
{
    private static readonly string DeathAnimatorString = "Death";
    private static readonly string JumpAttackAnimatorString = "JumpAttack";
    private static readonly string AttackAnimatorString = "Attack";
    private static readonly string RunAnimatorString = "Run";

    private Vehicle _player;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    [Header("Specifications")] [SerializeField]
    private float maxHealth = 100;

    [SerializeField] private float removeTime = 10;
    [SerializeField] private float radius = 10;
    [SerializeField] private float attackSpeed = 5;
    [SerializeField] private float damagePower = 45;
    [SerializeField] private float stopRange = 6.5F;
    [SerializeField] private float damageRange = 6.5F;
    [SerializeField] private float jumpPower = 7.5F;

    private float _health;

    public Rigidbody Rigidbody => _rigidbody;
    public Animator Animator => _animator;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private float _timer = 0;
    private float _deadTimer = 0;

    private bool _deathAnimation = false;


    public float Health => _health;
    public bool IsDead => _health <= 0;
    public float Timer => _timer;
    public float Radius => radius;
    public float AttackSpeed => attackSpeed;
    public float DamagePower => damagePower;
    public float StopRange => stopRange;
    public float DamageRange => damageRange;
    public float JumpPower => jumpPower;

    public virtual void Start()
    {
        _health = maxHealth;
        _player = FindTarget();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.stoppingDistance = stopRange;
    }

    public virtual void Update()
    {
        Walk();
        if (IsDead)
            Death();
        _timer += Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        GizmoShow();
    }

    private void GizmoShow()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Walk()
    {
        var velocity = Math.Abs(NavMeshAgent.velocity.magnitude);
        _animator.SetBool(RunAnimatorString, velocity >= 0.35F && !IsDead);
    }

    private void Death()
    {
        if (!_deathAnimation)
        {
            _deadTimer = _timer + removeTime;
            _deathAnimation = true;
            _animator.SetTrigger(DeathAnimatorString);
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


    public virtual void FaceTarget()
    {
        var direction = (Player.transform.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5F);
    }

    public float Distance()
    {
        var dist = Vector3.Distance(_player.transform.position, transform.position);
        return dist;
    }

    public virtual void Hit(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
    }

    public virtual void JumpAttack()
    {
        _animator.SetTrigger(JumpAttackAnimatorString);
    }

    public virtual void Kill()
    {
        Hit(float.MaxValue);
    }

    public virtual void Attack()
    {
        _animator.SetTrigger(AttackAnimatorString);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            Kill();
        }
    }
}