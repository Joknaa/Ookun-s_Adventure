using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float Thrust;
    public float KnockTime;
    public float Damage;

    private void OnTriggerEnter2D(Collider2D other)                                                       // "I AM SURE *MY SWORD* HIT SOMETHING !!"
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("PlayerSword"))                       // did i just hit a breakable thing ? ==> Smash it !
        {
            other.GetComponent<Pot>().Smash();                              
        }

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))        // "NO? THEN BRACE FOR IMPACTE !!"
        {
            Rigidbody2D OtherRigidbody = other.GetComponent<Rigidbody2D>();                          

            if(OtherRigidbody != null)
            {
                Vector2 difference = OtherRigidbody.transform.position - transform.position;         // get the vector of diraction between the player and the enemy ..
                Vector2 KnockbackForce = difference.normalized * Thrust;                             // calculat the force .. 
                OtherRigidbody.AddForce(KnockbackForce, ForceMode2D.Impulse);                        // apply the force .. 

                if (other.gameObject.CompareTag("enemy") && other.isTrigger)                                             // Knock back the enemy .. 
                {
                    KnockBackTheEnemy(other, OtherRigidbody);
                }
                if (other.gameObject.CompareTag("Player"))                                            // Knock back the player
                {
                    KnockBackThePlayer(other, OtherRigidbody);
                }
            }
        }
    }

    private void KnockBackThePlayer(Collider2D other, Rigidbody2D OtherRigidbody)
    {
        if (other.GetComponent<PlayerController>().PlayerCurrentState != PlayerState.stagger)     // .. only if he is not already staggered .. 
        {
            OtherRigidbody.GetComponent<PlayerController>().PlayerCurrentState = PlayerState.stagger;
            other.GetComponent<PlayerController>().Knock(KnockTime, Damage);
        }
    }

    private void KnockBackTheEnemy(Collider2D other, Rigidbody2D OtherRigidbody)
    {
        OtherRigidbody.GetComponent<Enemy>().EnemyCurrentState = EnemyState.stagger;
        other.GetComponent<Enemy>().Knock(OtherRigidbody, KnockTime, Damage);
    }

    private IEnumerator KnockCo(Rigidbody2D EnemyRigidbody)
    {
        if (EnemyRigidbody != null)
        {
            yield return new WaitForSeconds(KnockTime);

            EnemyRigidbody.velocity = Vector2.zero;
            EnemyRigidbody.GetComponent<Enemy>().EnemyCurrentState = EnemyState.idle;
            EnemyRigidbody.velocity = Vector2.zero;
        }
    }
}
