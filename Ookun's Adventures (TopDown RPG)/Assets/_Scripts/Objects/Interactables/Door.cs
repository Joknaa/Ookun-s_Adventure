using UnityEngine;


public enum DoorType
{
    Key,
    Enemy,
    Button
}

public class Door : Interactable
{   private bool DoorCondition;

    [Header("Door Variables: ")]
    public DoorType ThisDoorType;
    public bool IsOpen;
    public GameObject OpenedDoor;
    public GameObject LockedDoor;

    [Header("'KeyType'Door Variables: ")]
    public Inventory PlayerInventory;

    [Header("'LeverType'Door Variables: ")]
    public GameObject Lever;



    public virtual void Update()
    {
        switch (ThisDoorType)
        {
            case DoorType.Key:
                DoorCondition = PlayerInventory.NumberOfKeys > 0;
                break;
            case DoorType.Enemy:
                // enemy door condition ..
                break;
            case DoorType.Button:
                DoorCondition = Lever.GetComponent<Lever>().LeverIsOpen;
                break;
        }
        CheckForDoorCondition(DoorCondition);
    }

    private void CheckForDoorCondition(bool DoorCondition)
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (DoorCondition)
                {
                    OpenedDoor.SetActive(true);
                    LockedDoor.SetActive(false);
                }
                else
                {
                    ShowDialog();
                }
            }
        }
    }
}
