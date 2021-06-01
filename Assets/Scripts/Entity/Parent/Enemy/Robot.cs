using UnityEngine;

public class Robot : Entity
{
    [Header("Robot Specifications")] [SerializeField]
    private float ammoSpeed = 15F;

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
                    Attack();
                }
            }
        }

        base.Update();
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