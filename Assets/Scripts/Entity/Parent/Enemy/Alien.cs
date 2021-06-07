using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeInvocation")]
public class Alien : Entity
{
    [Header("Alien Specific")] [SerializeField]
    private float jumpPower = 7.5F;

    private bool _isFirstAttack = true;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!IsDead && !Player.IsDead)
        {
            if (Distance() < Radius)
            {
                NavMeshAgent.SetDestination(Player.transform.position);

                if (Distance() <= StopRange)
                {
                    FaceTarget();
                    if (_isFirstAttack)
                    {
                        JumpAttack();
                        _isFirstAttack = false;
                    }
                    else
                    {
                        Attack();
                    }
                }
            }
        }

        base.Update();
    }

    public override void JumpAttack()
    {
        Rigidbody.velocity += Vector3.up * jumpPower;
        Player.Hit(DamagePower * 1.5f, DamageType.Entity);
        base.JumpAttack();
    }

    public override void Attack()
    {
        if (!(Timer - LastAttackTime > AttackSpeed)) return;

        if (Timer % AttackSpeed <= 0.35F && Distance() <= DamageRange)
        {
            Player.Hit(DamagePower, DamageType.Entity);
            base.Attack();
        }
    }
}