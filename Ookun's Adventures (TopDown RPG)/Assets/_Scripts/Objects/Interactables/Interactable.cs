using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [Header("Interactable Variables: ")]
    public Signals InteractableSignal;
    public bool PlayerInRange;
    public InteractionBubbleManager Bubble;

    [Header("Dialog Variables: ")]
    public GameObject DialogDisplayBox;
    public Text DialogBox;
    public string DialogText;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Bubble.ChangeBubbleStatTo(true);
            InteractableSignal.Raise();
            PlayerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Bubble.ChangeBubbleStatTo(false);
            InteractableSignal.Raise();
            PlayerInRange = false;
            DialogDisplayBox.SetActive(false);
        }
    }

    public void ShowDialog()
    {
        if (DialogDisplayBox.activeInHierarchy)
        {
            DialogDisplayBox.SetActive(false);
        }
        else
        {
            DialogDisplayBox.SetActive(true);
            DialogBox.text = DialogText;
        }
    }
}
