public class Zombie : Entity
{
    public override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        if (!IsDead && Player.CanMove)
        {
            if (Distance() < Radius)
            {
                NavMeshAgent.SetDestination(Player.transform.position);

                if (Distance() <= StopRange)
                {
                    Attack();
                }
            }
        }
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