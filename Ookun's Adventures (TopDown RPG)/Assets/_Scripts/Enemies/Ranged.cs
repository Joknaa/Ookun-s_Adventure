using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemy
{
    [HideInInspector] public float FireDelayCount;

    [Header("Projectile Variables: ")]
    public GameObject Projectile;
    public Transform FirePoint;
    public float ProjectileSpeed;
    public float FireDelay;
    public bool CanShoot = true;

    public override void Start()
    {
        EnemyCurrentState = EnemyState.idle;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
        ChaseTarget = GameObject.FindWithTag("Player").transform;
        EnemyAnimator.SetBool("WakeUp", true);
        FireDelayCount = FireDelay;
    }

    void FixedUpdate()
    {
        ReactToPlayer();
        DelayBetweenShots();
        //CheckDestroyProjectile();
    }

    public virtual void ReactToPlayer() {}
    public void DelayBetweenShots()
    {
        if (CanShoot == false)
        {
            FireDelayCount -= Time.deltaTime;
            if (FireDelayCount <= 0)
            {
                CanShoot = true;
                FireDelayCount = FireDelay;
            }
            else
            {
                CanShoot = false;
            }
        }
    }

    //public virtual void CheckDestroyProjectile() {}
}
