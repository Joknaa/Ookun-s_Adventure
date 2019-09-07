using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D ProjectileRigidBody;
    [HideInInspector] public float LifeTimeCount;

    [Header("Projectile Variables: ")]
    public float LifeTime;


    public void Start()
    {
        ProjectileRigidBody = GetComponent<Rigidbody2D>();
        LifeTimeCount = LifeTime;
    }
    
    public void Update()
    {
        DestroyProjectileAfterLifeTime();
    }
    
    public void DestroyProjectileAfterLifeTime()
    {
        LifeTimeCount -= Time.deltaTime;
        if (LifeTimeCount <= 0)
        {
            Destroy(this.gameObject);
            LifeTimeCount = LifeTime;
        }
    }

    public void LaunchProjectile(Vector2 Velocity, float ProjectileSpeed)
    {
        ProjectileRigidBody.velocity = Velocity * ProjectileSpeed;
    }
}
