using UnityEngine;

public class TreasureChest : Interactable
{

    [Header("Chest Variables: ")]
    public Item ChestContents;
    public Inventory PlayerInventory;
    public bool IsOpen;
    public BoolValue IsOpenInMemory;
    public Signals ShowFoundItem;

    private Animator ChestAnimator;

    void Start()
    {
        ChestAnimator = GetComponent<Animator>();
        IsOpen = IsOpenInMemory.RunTimeValue;
        if (IsOpen)
        {
            ChestAnimator.SetBool("Opened", true);
        }
    }


    public void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!IsOpen)
                {
                    // Open the chest   
                    OpenTheChest();
                }
                else
                {
                    // leave the chest .. 
                    LeaveTheChest();
                }
            }
        }
    }

    public void OpenTheChest()
    {
        DialogDisplayBox.SetActive(true);
        Bubble.ChangeBubbleStatTo(false);
        DialogBox.text = ChestContents.ItemDescription;
        PlayerInventory.AddItem(ChestContents);
        PlayerInventory.ShowenItem = ChestContents;
        ShowFoundItem.Raise();
        InteractableSignal.Raise();
        IsOpen = true;
        ChestAnimator.SetBool("Opened", true);
        IsOpenInMemory.RunTimeValue = IsOpen;
    }

    public void LeaveTheChest()
    {
        DialogDisplayBox.SetActive(false);
        ShowFoundItem.Raise();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !IsOpen)
        {
            Bubble.ChangeBubbleStatTo(true);
            InteractableSignal.Raise();
            PlayerInRange = true;
        }
    }
}
