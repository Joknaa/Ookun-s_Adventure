using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator PotAnimator;

    void Start()
    {
        PotAnimator = GetComponent<Animator>();             // access the Pot Animator ..
    }

    public void Smash()
    {
        PotAnimator.SetBool("Smash", true);          // Show the destroy animation ..
        StartCoroutine(BreakCo());                   // Access BreakCo() Function ..
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.3f);               // wait for the Destroy animation to finish .. 
        this.gameObject.SetActive(false);                   // then disable the game object (Pot) ..
    }
}
