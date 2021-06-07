﻿using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeInvocation")]
public class Robot : Entity
{
    [Header("Robot Specifications")] [SerializeField]
    private GameObject bullet;

    [SerializeField] private bool followBullet = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!IsDead && !Player.IsDead)
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
        if (!(Timer - LastAttackTime > AttackSpeed)) return;
        if (Timer % AttackSpeed <= 0.35F && Distance() <= DamageRange)
        {
            Shoot();
            base.Attack();
        }
    }

    private void Shoot()
    {
        if (bullet != null)
        {
            var pos = transform.position;
            pos.y = pos.y + 3.7F;
            pos += transform.forward;
            var b = Instantiate(bullet, pos, transform.rotation);
            var bulletScript = b.GetComponent<Bullet>();
            bulletScript.Vehicle = Player;
            bulletScript.Follow = followBullet;
            bulletScript.Damage = DamagePower;
        }
    }
}