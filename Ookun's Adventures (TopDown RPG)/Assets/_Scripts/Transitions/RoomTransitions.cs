using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomTransitions: MonoBehaviour
{
    [HideInInspector] public CameraMovement CameraScript;

    [Header("Camera & Position Variables: ")]
    public Vector2 MaxCameraPositionChange;
    public Vector2 MinCameraPositionChange;
    public Vector3 PlayerChange;

    [Header("Place Name Variables: ")]
    public bool NeedText;
    public string PlaceName;
    public GameObject TextDisplayBox;
    public Text TextBox;

    void Start()
    {
        CameraScript = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CameraScript.MinPosition.x += MinCameraPositionChange.x;
            CameraScript.MinPosition.y += MinCameraPositionChange.y;
            CameraScript.MaxPosition.x += MaxCameraPositionChange.x;
            CameraScript.MaxPosition.y += MaxCameraPositionChange.y;
            other.transform.position += PlayerChange;
            if (NeedText)
            {
                StartCoroutine(PlaceNameCo());  
            }
        }
    }


    private IEnumerator PlaceNameCo()
    {
        TextDisplayBox.SetActive(true);
        TextBox.text = PlaceName;
        yield return new WaitForSeconds(4f);
        TextDisplayBox.SetActive(false);
    }
}