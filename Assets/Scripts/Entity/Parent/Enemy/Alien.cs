using UnityEngine;

public class Alien : Entity
{
    private bool _isFirstAttack = true;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!IsDead)
        {
            if (Distance() < Radius)
            {
                NavMeshAgent.SetDestination(Player.transform.position);

                if (Distance() < StopRange)
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
        Rigidbody.velocity += Vector3.up * JumpPower;
        Player.Hit(DamagePower / 2);
        base.JumpAttack();
    }

    public override void Attack()
    {
        if (Timer % AttackSpeed <= 0.35F && Distance() <= DamageRange)
        {
           
            
                Player.Hit(DamagePower);
                base.Attack();
           
        }
    }
}