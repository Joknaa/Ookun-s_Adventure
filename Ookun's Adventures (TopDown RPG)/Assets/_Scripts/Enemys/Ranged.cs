using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Enemy
{
    [HideInInspector] public RockProjectile ProjectileScript;
    [HideInInspector] public GameObject ThisProjectile;

    [Header("Projectile Variables: ")]
    public GameObject ProjectilePrefab;




    public void Start()
    {
        ThisProjectile = Instantiate(ProjectilePrefab);
        ProjectileScript = ThisProjectile.GetComponent<RockProjectile>();
        //ProjectileScript = GetComponent<RockProjectile>();
        EnemyCurrentState = EnemyState.idle;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
        ChaseTarget = GameObject.FindWithTag("Player").transform;
        EnemyAnimator.SetBool("WakeUp", true);

    }

    void FixedUpdate()
    {
        ReactToPlayer();
    }

    public virtual void ReactToPlayer() {}
}
