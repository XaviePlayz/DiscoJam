using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenuScript : MonoBehaviour
{
    public bool player1Ready, player2Ready;
    public GameObject player1ReadyText, player2ReadyText;
    public GameObject InstructionScene, GameScene;
    void Start()
    {
        player1Ready = false;
        player2Ready = false;       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player1Ready = true;
            player1ReadyText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player2Ready = true;
            player2ReadyText.SetActive(true);
        }
        if (player1Ready == true && player2Ready == true)
        {
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        GameScene.SetActive(true);
        InstructionScene.SetActive(false);
        StopCoroutine(StartGame());
    }
}
