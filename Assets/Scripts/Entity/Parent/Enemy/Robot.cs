using UnityEngine;

public class Robot : Entity
{
    [Header("Robot Specifications")] [SerializeField]
    private GameObject bullet;

    private float _lastAttackTime = 0;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!IsDead)
        {
            if (Distance() <= Radius)
            {
                NavMeshAgent.SetDestination(Player.transform.position);

                if (Distance() <= StopRange)
                {
                    FaceTarget();
                    Attack();
                }
            }
        }

        base.Update();
    }

    public override void Attack()
    {
        var canAttack = Timer % AttackSpeed <= 0.35F && Distance() <= DamageRange;
        if (canAttack)
        {
            if (!(Timer - _lastAttackTime > AttackSpeed)) return;
            _lastAttackTime = Timer;
            Shoot();
            base.Attack();
        }
    }
    
    private void Shoot()
    {
        if (bullet != null)
        {
            var pos = transform.position;
            pos.y = pos.y + 2.5f;
            pos += transform.forward;
            var b = Instantiate(bullet, pos, transform.rotation);
            var bulletScript = b.GetComponent<Bullet>();
            bulletScript.Damage = DamagePower;
        }
    }
}