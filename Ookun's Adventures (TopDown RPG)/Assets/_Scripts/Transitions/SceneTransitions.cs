using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public enum Scenes
{
    TheWorld,
    HouseInteriour,
    Dungeon
}
public class SceneTransitions : MonoBehaviour
{
    [Header("Scenes available: ")]
    public Scenes SceneToLoad;

    [Header("New Scene Variables: ")]
    public VectorValue PlayerPositionMemory;
    public Vector2 PlayerPosition;
    public Vector2 CameraNewMax;
    public Vector2 CameraNewMin;
    public VectorValue CameraMax;
    public VectorValue CameraMin;

    [Header("Transition Effect Animator: ")]
    public Animator FadeAnimator;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPositionMemory.InitialValue = PlayerPosition;
            FadeAnimator.SetTrigger("SceneToFade");
        }
    }

    public void LoadSceneAfterAnimation()
    {
        ResetCameraBounds();
        SceneManager.LoadScene(SceneToLoad.ToString());
    }


    void ResetCameraBounds()
    {
        CameraMax.InitialValue = CameraNewMax;
        CameraMin.InitialValue = CameraNewMin;
    }
}
