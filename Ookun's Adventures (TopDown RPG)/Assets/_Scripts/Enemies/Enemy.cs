using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState {
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Animator EnemyAnimator;
    [HideInInspector] public Rigidbody2D EnemyRigidbody;
    [HideInInspector] public Transform ChaseTarget;
    private readonly float DeathEffectDelay = 1f;  // "readonly" is like Const .. but i can change its value after i declare it ..

    [Header("Effects: ")]
    public GameObject DeathEffect;

    [Header("Enemy State : ")]
    public EnemyState EnemyCurrentState;

    [Header("Enemy Stats: ")]
    public FloatValue MaxHealth;
    public string Name;
    public float Health;
    public float BaseAttackDamage;
    public float MoveSpeed;
    public float ChaseRange;
    public float AttackRange;


    private void Awake()
    {
        Health = MaxHealth.InitialValue;
    }

    public virtual void Start()
    {
        EnemyCurrentState = EnemyState.idle;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyAnimator = GetComponent<Animator>();
        ChaseTarget = GameObject.FindWithTag("Player").transform;                // set a target ..
        EnemyAnimator.SetBool("WakeUp", true);
    }

    public void TakeDamage(float Damage)
    {
        FindObjectOfType<AudioManager>().PlaySound("Hurt");
        Health -= Damage;
        if (Health <= 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("Death");
            EnemyDeathEffect();
            this.gameObject.SetActive(false);
        }
    }

    private void EnemyDeathEffect()
    {
        if (DeathEffect != null)
        {
            GameObject Effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(Effect, DeathEffectDelay);
        }
    }

    public virtual void Knock (Rigidbody2D PlayerRigidbody, float KnockTime, float Damage)
    {
        StartCoroutine(KnockCo(PlayerRigidbody, KnockTime));
        TakeDamage(Damage);
    }

    public virtual IEnumerator KnockCo(Rigidbody2D PlayerRigidbody, float KnockTime)    // setting the knockback feature to the player also
    {
        if (PlayerRigidbody != null)
        {
            yield return new WaitForSeconds(KnockTime);
            PlayerRigidbody.velocity = Vector2.zero;
            EnemyCurrentState = EnemyState.idle;
            PlayerRigidbody.velocity = Vector2.zero; // 2 of them ??
        }
    }


    public virtual void MoveEnemyTowardsTarget(Transform Target)
    {
        if (EnemyCurrentState == EnemyState.walk || EnemyCurrentState == EnemyState.idle && EnemyCurrentState != EnemyState.stagger)      // is the enemy able to move ?
        {
            Vector3 DirectionTotarget = Vector3.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);          // Calculate the distance to chase ..  
            UpdateEnemyAnimation(DirectionTotarget - transform.position);
            EnemyRigidbody.MovePosition(DirectionTotarget);                                                                               // Start the chase ..
            ChangeEnemyStateTo(EnemyState.walk);                                                                                   // Set the enemy state to "Walk" ..
            EnemyAnimator.SetBool("WakeUp", true);
        }
    }

    public virtual void SetEnemyAnimationFloats(Vector2 Direction)
    {
        EnemyAnimator.SetFloat("MoveX", Direction.x);
        EnemyAnimator.SetFloat("MoveY", Direction.y);
    }

    public virtual void UpdateEnemyAnimation(Vector2 Direction)
    {
        if (Mathf.Abs(Direction.x) > Mathf.Abs(Direction.y))
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
        else if (Mathf.Abs(Direction.x) < Mathf.Abs(Direction.y))
        {
            if (Direction.y > 0)                // up
            {
                SetEnemyAnimationFloats(Vector2.up);
            }
            else if (Direction.y < 0)           // down
            {
                SetEnemyAnimationFloats(Vector2.down);
            }
        }
    }

    public void ChangeEnemyStateTo(EnemyState NewState)
    {
        if (NewState != EnemyCurrentState)
        {
            EnemyCurrentState = NewState;
        }
    }
}


