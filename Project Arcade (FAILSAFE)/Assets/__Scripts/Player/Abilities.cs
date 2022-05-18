using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public static Abilities instance;

    [Header("LeftPlayer")]
    public Image LeftPlayer_Block;
    public Image LeftPlayer_Punch;
    public Image LeftPlayer_Kick;
    public Image LeftPlayer_Health;
    public bool LeftPlayer_hasAttacked;

    [Header("LeftPlayer Animations")]
    public Animator LeftBlock;
    public Animator Player1_anim;

    private bool leftPlayerisBlocking = false;  

    [Header("RightPlayer")]
    public Image RightPlayer_Block;
    public Image RightPlayer_Punch;
    public Image RightPlayer_Kick;
    public Image RightPlayer_Health;
    public bool RightPlayer_hasAttacked;

    [Header("RightPlayer Animations")]
    public Animator RightBlock;
    public Animator Player2_anim;

    private bool rightPlayerisBlocking = false;


    void Start()
    {
        LeftPlayer_Block.fillAmount = 0;
        LeftPlayer_Punch.fillAmount = 0;
        LeftPlayer_Kick.fillAmount = 0;
        RightPlayer_Block.fillAmount = 0;
        RightPlayer_Punch.fillAmount = 0;
        RightPlayer_Kick.fillAmount = 0;

        LeftPlayer_Health.fillAmount = 1;
        RightPlayer_Health.fillAmount = 1;

        LeftPlayer_hasAttacked = false;
        RightPlayer_hasAttacked = false;
    }

    void Update()
    {        
        if (!GameManager.instance.gameEnded)
        {
            LeftAbillity();
            RightAbillity();
        }
    }

    void LeftAbillity()
    {
        if (LeftPlayer_hasAttacked == false)
        {
            if (LeftPlayer_Block.fillAmount == 1)
            {
                Debug.Log("Block");
                leftPlayerisBlocking = true;
                LeftPlayer_Block.fillAmount = 0;
                StartCoroutine(Blocking(true));
            }
            if (LeftPlayer_Punch.fillAmount == 1)
            {
                StartCoroutine(LeftPlayerHasAttacked());
                Player2_anim.SetTrigger("Punch");
                Debug.Log("Punch");
                LeftPlayer_Punch.fillAmount = 0;
                if (rightPlayerisBlocking == false)
                    RightPlayer_Health.fillAmount -= 0.07f * GameManager.instance.currentmultiplier1;
                Player2_anim.SetBool("Idle", true);
            }
            if (LeftPlayer_Kick.fillAmount == 1)
            {
                StartCoroutine(LeftPlayerHasAttacked());
                Player2_anim.SetTrigger("Kick");
                Debug.Log("Kick");
                LeftPlayer_Kick.fillAmount = 0;
                if (rightPlayerisBlocking == false)
                    RightPlayer_Health.fillAmount -= 0.1f * GameManager.instance.currentmultiplier1;
                Player2_anim.SetBool("Idle", true);
            }
        }       
    }
    void RightAbillity()
    {
        if (RightPlayer_hasAttacked == false)
        {
            if (RightPlayer_Block.fillAmount == 1)
            {
                Debug.Log("Block");
                rightPlayerisBlocking = true;
                RightPlayer_Block.fillAmount = 0;
                StartCoroutine(Blocking(false));
            }
            if (RightPlayer_Punch.fillAmount == 1)
            {
                StartCoroutine(RightPlayerHasAttacked());
                Player1_anim.SetTrigger("Punch");
                Debug.Log("Punch");
                RightPlayer_Punch.fillAmount = 0;
                if (leftPlayerisBlocking == false)
                    LeftPlayer_Health.fillAmount -= 0.07f * GameManager.instance.currentmultiplier2;
                Player1_anim.SetBool("Idle", true);
            }
            if (RightPlayer_Kick.fillAmount == 1)
            {
                StartCoroutine(RightPlayerHasAttacked());
                Player1_anim.SetTrigger("Kick");
                Debug.Log("Kick");
                RightPlayer_Kick.fillAmount = 0;
                if (leftPlayerisBlocking == false)
                    LeftPlayer_Health.fillAmount -= 0.1f * GameManager.instance.currentmultiplier2;
                Player1_anim.SetBool("Idle", true);
            }
        }        
    }

    IEnumerator Blocking(bool player)// true == left player and right == right
    {
        if (player)
        {
            leftPlayerisBlocking = true;
            //LeftPlayer_Health.color = new Color(0, 255, 233, 255);
            LeftBlock.SetTrigger("Block");
        }
        else
        {
            rightPlayerisBlocking = true;
            // RightPlayer_Health.color = new Color(0, 255, 233, 255);
            RightBlock.SetTrigger("Block");
        }
        yield return new WaitForSeconds(2);
        if (player)
        {
            leftPlayerisBlocking = false;
           // LeftPlayer_Health.color = new Color(255, 255, 255, 255);
        }
        else
        {
            rightPlayerisBlocking = false;
            //RightPlayer_Health.color = new Color(255, 255, 255, 255);
        }
    }
    IEnumerator LeftPlayerHasAttacked()
    {
        LeftPlayer_hasAttacked = true;
        yield return new WaitForSeconds(2);
        LeftPlayer_hasAttacked = false;
        StopCoroutine(LeftPlayerHasAttacked());
    }
    IEnumerator RightPlayerHasAttacked()
    {
        RightPlayer_hasAttacked = true;
        yield return new WaitForSeconds(2);
        RightPlayer_hasAttacked = false;
        StopCoroutine(RightPlayerHasAttacked());
    }
}
