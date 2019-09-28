using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : Ranged
{
    [Header("Torret Variables: ")]
    public Collider2D GuardedArea;

    public override void ReactToPlayer()
    {
        bool InsideArea = GuardedArea.bounds.Contains(ChaseTarget.transform.position);
        if (InsideArea)
        {
            if (CanShoot)
            {
                ShootTheTarget();
            }
        }
        else
        {
            StopShooting();
        }
    }


    public void ShootTheTarget()
    {
        if (EnemyCurrentState == EnemyState.walk || EnemyCurrentState == EnemyState.idle && EnemyCurrentState != EnemyState.stagger)
        {
            CanShoot = false;
            Vector3 DirectionToTarget = ChaseTarget.transform.position - transform.position;
            EnemyAnimator.SetBool("WakeUp", true);
            ChangeEnemyStateTo(EnemyState.walk);
            UpdateEnemyAnimation(DirectionToTarget);

            GameObject CloneProjectile = Instantiate(Projectile, FirePoint.position, Quaternion.identity);
            CloneProjectile.GetComponent<Projectile>().LaunchProjectile(DirectionToTarget, ProjectileSpeed);
        }
    }

    public void StopShooting()
    {
        ChangeEnemyStateTo(EnemyState.idle);
        EnemyAnimator.SetBool("WakeUp", false);
    }


    public override void Knock(Rigidbody2D PlayerRigidbody, float KnockTime, float Damage)
    {
        EnemyCurrentState = EnemyState.idle;
        TakeDamage(Damage);
    }
}
