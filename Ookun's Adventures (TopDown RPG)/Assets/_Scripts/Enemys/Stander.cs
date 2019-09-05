using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stander : Melee
{


    public override void ReactToPlayer()
    {
        float DistancetoTarget = Vector3.Distance(ChaseTarget.position, transform.position);

        if ((DistancetoTarget <= ChaseRange) && (DistancetoTarget > AttackRange))                                                           // Is that target in range ?  
        {
            MoveEnemyTowardsTarget(ChaseTarget);
        }
        else if (DistancetoTarget > ChaseRange)
        {
            EnemyAnimator.SetBool("WakeUp", false);
        }
    }

}
