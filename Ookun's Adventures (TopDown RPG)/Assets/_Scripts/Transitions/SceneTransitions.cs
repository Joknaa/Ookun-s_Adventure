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
    public GameObject SceneTransition;

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
            SceneTransition.SetActive(true);
            FadeAnimator.SetTrigger("SceneToFade");
        }
    }

    public IEnumerator LoadSceneAfterAnimation()
    {
        ResetCameraBounds();
        SceneManager.LoadScene(SceneToLoad.ToString());
        yield return new WaitForSecondsRealtime(1);
        SceneTransition.SetActive(false);


    }


    void ResetCameraBounds()
    {
        CameraMax.InitialValue = CameraNewMax;
        CameraMin.InitialValue = CameraNewMin;
    }
}
