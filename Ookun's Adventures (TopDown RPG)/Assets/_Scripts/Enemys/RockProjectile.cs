using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : Projectile
{
    //public GameObject ProjectileType;
    /*

    public void SendProjectile(GameObject ProjectileType, Transform target, Transform Sender, int TravelSpeed, float ProjectileAttackDelay)
    {
        Debug.Log("Starting the 'SendProjectile' method  ..");
        StartCoroutine(SendProjectileCo(ProjectileType, target, Sender, TravelSpeed, ProjectileAttackDelay));
    }*/
    /*
    public override IEnumerator SendProjectileCo(GameObject ProjectileType, Transform target, Transform Sender, int TravelSpeed, float ProjectileAttackDelay)
    {
        Debug.Log("Starting the Courotine ..");

        Vector3 DirectionTotarget = Vector3.MoveTowards(transform.position, target.position, TravelSpeed * Time.deltaTime);
        GameObject TempProjectile;
        TempProjectile = Instantiate(ProjectileType, Sender.position, Quaternion.identity);
        ProjectileRigidBody.MovePosition(DirectionTotarget);
        Destroy(TempProjectile, 5f);

        yield return new WaitForSeconds(ProjectileAttackDelay);
    }
    */

}
