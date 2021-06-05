public class Zombie : Entity
{
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
                    Attack();
                }
            }
        }

        base.Update();
    }

    public override void Attack()
    {
        if (!(Timer - LastAttackTime > AttackSpeed)) return;

        if (Timer % AttackSpeed <= 0.35F && Distance() <= DamageRange)
        {
            Player.Hit(DamagePower);
            base.Attack();
        }
    }
}