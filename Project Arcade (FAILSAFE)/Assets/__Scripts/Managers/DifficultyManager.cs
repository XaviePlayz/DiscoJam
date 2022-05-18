using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject easy, normal, hard;
    public void Start()
    {
        if (SceneManagerScript.instance.difficultyIndex == 1)
        {
            easy.SetActive(true);
        }
        else if (SceneManagerScript.instance.difficultyIndex == 2)
        {
            normal.SetActive(true);
        }
        else
        {
            hard.SetActive(true);
        }
    }
}
