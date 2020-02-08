using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DG_Enemy : Enemy
{

    public override void Start()
    {
        EnemyCurrentState = EnemyState.idle;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
        ChaseTarget = GameObject.FindWithTag("Player").transform;                // set a target ..
        //EnemyAnimator.SetBool("WakeUp", true);
    }

    public override void MoveEnemyTowardsTarget(Transform Target)
    {
        if (EnemyCurrentState == EnemyState.walk || EnemyCurrentState == EnemyState.idle && EnemyCurrentState != EnemyState.stagger)      
        {
            Vector3 DirectionTotarget = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);          
            UpdateEnemyAnimation(DirectionTotarget - transform.position);
            EnemyRigidbody.MovePosition(DirectionTotarget);                                                                               
            ChangeEnemyStateTo(EnemyState.walk);
            EnemyAnimator.SetBool("Moving", true);
        }
    }

    public override void SetEnemyAnimationFloats(Vector2 Direction)
    {
        EnemyAnimator.SetFloat("MoveX", Direction.x);
    }


    public override void UpdateEnemyAnimation(Vector2 Direction)
    {
        if (Direction.x > 0)                // right 
        {
            SetEnemyAnimationFloats(Vector2.right);
        }
        else if (Direction.x < 0)           // left 
        {
            SetEnemyAnimationFloats(Vector2.left);
        }
    }
}
