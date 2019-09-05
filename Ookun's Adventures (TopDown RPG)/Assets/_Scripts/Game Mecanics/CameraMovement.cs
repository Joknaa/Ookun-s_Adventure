using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [HideInInspector] public Animator CameraAnimator;

    [Header("Camera Settings: ")]
    public Transform target;
    public float smoothing;
    public Vector2 MaxPosition;
    public Vector2 MinPosition;

    [Header("Camera Reset: ")]
    public VectorValue CameraNewMax;
    public VectorValue CameraNewMin;


    private void Start()
    {
        MaxPosition = CameraNewMax.InitialValue;
        MinPosition = CameraNewMin.InitialValue;
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        CameraAnimator = GetComponent<Animator>();
    }


    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);

            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    public void StartScreenKick()
    {
        CameraAnimator.SetBool("ScreenKick", true);
    }

    public void FinishScreenKick()
    {
        CameraAnimator.SetBool("ScreenKick", false);
    }
}