using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : Melee
{
    [Header("Patrolling Variables: ")]
    public Transform[] Path;
    public int CurrentPoint;
    public Transform CurrentGoal;
    public float RoundingDistance;




    public override void ReactToPlayer()
    {
        float DistancetoTarget = Vector3.Distance(ChaseTarget.position, transform.position);
        if ((DistancetoTarget <= ChaseRange) && (DistancetoTarget > AttackRange))                                                           // Is that target in range ?  
        {
            MoveEnemyTowardsTarget(ChaseTarget);
        }
        else if (DistancetoTarget > ChaseRange)
        {
            ReturnToPatrolling();
        }
    }


    private void ReturnToPatrolling()
    {
        if (Vector3.Distance(transform.position, Path[CurrentPoint].position) > RoundingDistance)
        {   // the current path is available .. 
            Vector3 DirectionToGoal = Vector3.MoveTowards(transform.position, Path[CurrentPoint].position, MoveSpeed * Time.deltaTime);          // returne to the patrol path ..
            UpdateEnemyAnimation(DirectionToGoal - transform.position);
            EnemyRigidbody.MovePosition(DirectionToGoal);
        }
        else
        {   // update patrol path ..
            if (CurrentPoint == Path.Length - 1)
            {
                CurrentPoint = 0;
                CurrentGoal = Path[0];
            }
            else 
            {
                CurrentPoint++;
                CurrentGoal = Path[CurrentPoint];
            }
        }
    }
}