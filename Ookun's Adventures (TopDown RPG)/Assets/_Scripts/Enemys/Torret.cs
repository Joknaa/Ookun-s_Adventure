using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : Ranged
{
    [Header("Torret Variables: ")]
    public Collider2D GuardedArea;
    public int ProjectileSpeed;
    public float ProjectileAttackDelay;



    public override void ReactToPlayer()
    {
        bool InsideArea = GuardedArea.bounds.Contains(ChaseTarget.transform.position);
        if (InsideArea)
        {
            ShootTheTarget();
        }
        else
        {
            StopShooting();
        }
    }


    public void ShootTheTarget()
    {
        EnemyAnimator.SetBool("WakeUp", true);
        ChangeEnemyStateTo(EnemyState.attack);
        Vector3 DirectionTotarget = Vector3.MoveTowards(transform.position, ChaseTarget.position, MoveSpeed * Time.deltaTime);
        UpdateEnemyAnimation(DirectionTotarget - transform.position);
        ProjectileScript.SendProjectile(ThisProjectile, ChaseTarget, transform, ProjectileSpeed, ProjectileAttackDelay);
    }

    public void StopShooting()
    {
        ChangeEnemyStateTo(EnemyState.idle);
        EnemyAnimator.SetBool("WakeUp", false);
    }
}
