using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite HalfFullHeart;
    public Sprite EmptyHeart;
    public FloatValue HeartConteinersCount;
    public FloatValue PlayerCurrentHealth;


    void Start()
    {
        InitializeHearts();
    }

    public void InitializeHearts()
    {
        for (int i = 0; i < HeartConteinersCount.InitialValue; i++)
        {
            Hearts[i].gameObject.SetActive(true);
            Hearts[i].sprite = FullHeart;
        }
    }


    public void UpdateHearts()
    {
        float hp = PlayerCurrentHealth.RuntimeValue / 2 - 1;
        for (int i = 0; i < HeartConteinersCount.InitialValue; i++)
        {
            if (hp > i)
            {
                Hearts[i].sprite = FullHeart;
            }
            else if (hp < i && hp > i-1)
            {
                Hearts[i].sprite = HalfFullHeart;
            }
            else if (hp <= i-1)
            {
                Hearts[i].sprite = EmptyHeart;
            }
        }
    }
}
