using UnityEngine;


public class Lever : Interactable
{
    [Header("Lever Variables: ")]
    public GameObject LeverOpen;
    public GameObject LeverClose;
    public bool LeverIsOpen;

    public void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LeverIsOpen = true;            
                LeverClose.SetActive(false);
                LeverOpen.SetActive(true);
            }
        }
    }
}

