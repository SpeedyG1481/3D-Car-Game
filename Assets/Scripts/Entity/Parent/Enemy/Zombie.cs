using System;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeInvocation")]
public class Zombie : Entity
{
    public float moveSpeed = 12.5F, trackingRange = 50, minDamageRange = 10, jumpRange = 25, jumpAmount = 10;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!IsDead)
        {
            HandleMovement();
        }

        base.Update();
    }

    private void HandleMovement()
    {
        if (Distance() < trackingRange)
        {
            if (minDamageRange > Distance() && IsJumping)
            {
                IsJumping = false;
                Player.Hit(12.5F);
                Hit(float.MaxValue);
            }

            else if (jumpRange > Distance() && !IsJumping)
            {
                Jump(jumpAmount);
            }
            else if (minDamageRange < Distance())
            {
                Chase(moveSpeed + Math.Abs(Player.Speed / (3 * 3.6F)));
            }
        }
    }
}