using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator)),
 RequireComponent(typeof(CapsuleCollider)), RequireComponent(typeof(AudioSource))]
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
    private CapsuleCollider _capsuleCollider;
    private AudioSource _audioSource;

    [Header("Specifications")] [SerializeField]
    private float maxHealth = 100;

    [SerializeField] private float removeTime = 10;
    [SerializeField] private float radius = 10;
    [SerializeField] private float attackSpeed = 5;
    [SerializeField] private float damagePower = 45;
    [SerializeField] private float stopRange = 6.5F;
    [SerializeField] private float damageRange = 6.5F;

    [Header("Sounds")] [SerializeField] private AudioClip idlingAndRunning;
    [SerializeField] private AudioClip attacking;
    [SerializeField] private AudioClip death;

    private float _health;

    public Rigidbody Rigidbody => _rigidbody;
    public Animator Animator => _animator;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;

    private float _timer = 0;
    private float _deadTimer = 0;
    private float _lastAttackTime = 0;

    private bool _deathAnimation = false;


    public float Health => _health;
    public bool IsDead => _health <= 0;
    public float Timer => _timer;
    public float Radius => radius;
    public float AttackSpeed => attackSpeed;
    public float DamagePower => damagePower;
    public float StopRange => stopRange;
    public float DamageRange => damageRange;
    public float LastAttackTime => _lastAttackTime;

    public virtual void Start()
    {
        _health = maxHealth;
        _player = FindTarget();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.maxDistance = radius;
        _navMeshAgent.stoppingDistance = stopRange;
    }

    public virtual void Update()
    {
        SoundController();
        Walk();
        if (IsDead)
            Death();
        _timer += Time.deltaTime;
    }

    private void SoundController()
    {
        _audioSource.volume = GameController.GetSfxVolume;
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
        var isWalking = velocity >= 0.35F && !IsDead;
        _animator.SetBool(RunAnimatorString, isWalking);
        if (isWalking && !_audioSource.isPlaying)
        {
            _audioSource.clip = idlingAndRunning;
            _audioSource.Play();
        }
    }

    private void Death()
    {
        if (!_deathAnimation)
        {
            _deathAnimation = true;
            _deadTimer = _timer + removeTime;
            _capsuleCollider.isTrigger = true;
            _animator.SetTrigger(DeathAnimatorString);
            _audioSource.clip = death;
            _audioSource.Stop();
            _audioSource.PlayOneShot(death, GameController.GetSfxVolume);
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
        var dist = Vector3.Distance(_player.CenterOfMass.position, transform.position);
        return dist;
    }

    public virtual void Hit(float damage)
    {
        if (IsDead) return;
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
        _lastAttackTime = _timer;
        _animator.SetTrigger(AttackAnimatorString);
        _audioSource.clip = attacking;
        _audioSource.Stop();
        _audioSource.PlayOneShot(attacking, GameController.GetSfxVolume);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Vehicle"))
        {
            Kill();
        }
    }
}