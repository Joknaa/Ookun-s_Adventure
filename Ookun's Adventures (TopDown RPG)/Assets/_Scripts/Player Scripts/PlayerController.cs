using System.Collections;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
} 

public class PlayerController : MonoBehaviour
{
    [HideInInspector] private Rigidbody2D PlayerRigidbody;
    [HideInInspector] public Animator PlayerAnimator;
    private Vector3 Change;
    private float DeathEffectDelay = 1f;


    public GameObject DeathEffect;
    public Signals ScreenKickSignal;
    public float Speed;

    [Header("Passive Variables: ")]
    public PlayerState PlayerCurrentState;
    public FloatValue PlayerInitialHealth;
    public FloatValue PlayerCurrentHealth;
    public VectorValue PlayerStartingPosition;
    public Signals PlayerHealthSignal;

    [Header("Inventory Variables: ")]
    public Inventory PlayerInventory;
    public SpriteRenderer ReceivedItemSprite;

    [Header("GameStat: ")]
    public GameStatEnum GameStat;


    void Start()
    {
        PlayerCurrentState = PlayerState.walk;
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetFloat("MoveX", 0);
        PlayerAnimator.SetFloat("MoveY", -1);
        PlayerInitialHealth.InitialValue = 6;
        transform.position = PlayerStartingPosition.InitialValue;
    }

    void FixedUpdate()
    {
        if (PlayerCurrentState == PlayerState.interact) { return; }         // Is the player in an Interaction ? 

        // if not .. then play !
        Change = Vector3.zero;
        Change.x = Input.GetAxisRaw("Horizontal");
        Change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && PlayerCurrentState != PlayerState.attack && PlayerCurrentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (PlayerCurrentState == PlayerState.walk || PlayerCurrentState == PlayerState.idle)
        {
            UpdatePlayerAnimationAndMove();
        }

    }

    void UpdatePlayerAnimationAndMove()
    {
        if (Change != Vector3.zero)
        {
            MovePlayer();
            PlayerAnimator.SetFloat("MoveX", Change.x);
            PlayerAnimator.SetFloat("MoveY", Change.y);
            PlayerAnimator.SetBool("Moving", true);
        }
        else
        {
            PlayerAnimator.SetBool("Moving", false);
        }
    }
    void MovePlayer()
    {
        Change.Normalize();
        PlayerRigidbody.MovePosition(transform.position + Change * Speed * Time.deltaTime);
    }

    public void Knock(float KnockTime, float Damage) // initial the knockback and Damage code ..
    {
        FindObjectOfType<AudioManager>().PlaySound("Hurt");

        PlayerCurrentHealth.RuntimeValue -= Damage;
        PlayerHealthSignal.Raise();

        if (PlayerCurrentHealth.RuntimeValue > 0)  // only if the player is not dead already XD .. 
        {
            StartCoroutine(KnockCo(KnockTime));
        } else
        {
            this.gameObject.SetActive(false);
            PlayerDeathEffect();
            // i can send a signal for GameOver here ! 
        }
    }

    public void PlayerDeathEffect()
    {
        FindObjectOfType<AudioManager>().PlaySound("Death");
        GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, DeathEffectDelay);

    }


    private IEnumerator KnockCo(float KnockTime)    // Knocking back the player ..
    {
        ScreenKickSignal.Raise();
        if (PlayerRigidbody != null)
        {
            yield return new WaitForSeconds(KnockTime);
            PlayerRigidbody.velocity = Vector2.zero;
            PlayerCurrentState = PlayerState.idle;
            PlayerRigidbody.velocity = Vector2.zero;
        }
    }
    private IEnumerator AttackCo()
    {
        FindObjectOfType<AudioManager>().PlaySound("Sword");
        PlayerAnimator.SetBool("Attacking", true);          // transition to the Attack state in the Animator .. 
        PlayerCurrentState = PlayerState.attack;              // set the current state to Attack ..
        yield return null;                              // wait for 1 frame ..
        PlayerAnimator.SetBool("Attacking", false);         // since i did a transition from Any State to Attacking, this will stop the loop of Attacking to Attacking ..
        yield return new WaitForSeconds(.2f);           // wait for animation to end (0.3 sec) .. 
        if (PlayerCurrentState != PlayerState.interact)  // is the player is in multiple page interaction ..
        {
            PlayerCurrentState = PlayerState.walk;                // reset the state to walk ..
        }
    }

    public void ShowFoundItem()
    {
        if (PlayerInventory.ShowenItem != null)
        {
            if (PlayerCurrentState != PlayerState.interact)
            {
                PlayerAnimator.SetBool("ShowingItem", true);
                PlayerCurrentState = PlayerState.interact;
                ReceivedItemSprite.sprite = PlayerInventory.ShowenItem.ItemSprite;

            }
            else
            {
                PlayerAnimator.SetBool("ShowingItem", false);
                PlayerCurrentState = PlayerState.idle;
                ReceivedItemSprite.sprite = null;
                PlayerInventory.ShowenItem = null;
            }
        }
    }
}
