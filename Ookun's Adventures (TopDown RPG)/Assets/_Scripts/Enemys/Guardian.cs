using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Melee
{
    [Header("Guarding Variables: ")]
    public Collider2D GuardedArea;
    public Transform GuardPostLocation;
    public float RoundingDistance;


    public override void ReactToPlayer()
    {
        bool InsideArea = GuardedArea.bounds.Contains(ChaseTarget.transform.position);

        if (InsideArea)
        {
            MoveEnemyTowardsTarget(ChaseTarget);
        }
        else if (!InsideArea)
        {
            GetBackToGuardPost();
        }
    }

    public void GetBackToGuardPost()
    {
        MoveEnemyTowardsTarget(GuardPostLocation);
        float DistanceToLocation = Vector3.Distance(transform.position, GuardPostLocation.position);
        if (DistanceToLocation < RoundingDistance)
        {
            ChangeEnemyStateTo(EnemyState.idle);
            EnemyAnimator.SetBool("WakeUp", false);
        }
    }

}
