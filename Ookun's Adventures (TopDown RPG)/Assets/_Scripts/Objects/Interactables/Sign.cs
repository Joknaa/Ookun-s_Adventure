using UnityEngine;


public class Sign : Interactable
{
    void Update()
    {
        if (PlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowDialog();
            }
        }
    }
}