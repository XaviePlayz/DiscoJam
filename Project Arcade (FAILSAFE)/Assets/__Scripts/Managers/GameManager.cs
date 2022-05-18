using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameStarted = false;
    public static GameManager instance;
    [SerializeField]
    private Abilities abilities;

    public bool gameEnded = false;
    [Header("Animators")]
    public Animator ScoreBoard;
    public Animator continueButton;
    public Animator Abillities;


    public GameObject MissParticle, NormalParticle, PerfectParticle;

    public int totalNotes;

    [Header("Click Heights")]
    public float minNormalClickHeight;
    public float maxNormalClickHeight;
    public float minPerfectClickHeight;
    public float maxPerfectClickHeight;


    [Header("Score per Hit")]
    public int currentScore1;
    public int currentScore2;
    public int scorePerNote = 1;
    public int scorePerPerfectNote = 2;

    [Header("Player1 noteHits")]

    public int normalHits1;
    public int perfectHits1;
    public int missedHits1;
    public int notesLeft1;
    public int multiplierTracker1;
    public int currentmultiplier1;
    public int[] multiplierThresholds1;

    public TextMeshProUGUI normalHitText1, perfectHitText1, missHitText1, rankText1, finalScoreText1, player1Wins, CurrentScorePlayer1;

    [Header("LeftPlayer")]
    public Image LeftPlayer_Block;
    public Image LeftPlayer_Punch;
    public Image LeftPlayer_Kick;

    [Header("Player2 noteHits")]
    public int normalHits2;
    public int perfectHits2;
    public int missedHits2;
    public int notesLeft2;
    public int multiplierTracker2;
    public int currentmultiplier2;
    public int[] multiplierThresholds2;

    [Header("RightPlayer")]
    public Image RightPlayer_Block;
    public Image RightPlayer_Punch;
    public Image RightPlayer_Kick;

    public TextMeshProUGUI normalHitText2, perfectHitText2, missHitText2, rankText2, finalScoreText2, player2Wins, CurrentScorePlayer2;

    private bool CanLeave = false;
    void Start()
    {
        CanLeave = false;
        currentmultiplier1 = 1;
        currentmultiplier2 = 1;
        instance = this;
        totalNotes = FindObjectsOfType<noteScript1>().Length;
        notesLeft1 = totalNotes;
        notesLeft2 = totalNotes;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameEnded = false;
        GameStarted = false;
        CurrentScorePlayer2.text = "0";
        CurrentScorePlayer1.text = "0";

    }

    void Update()
    {
        if (notesLeft1 == 0 && notesLeft2 == 0 && !gameEnded)
        {
            StartCoroutine(ShowScore());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (CanLeave && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad4) && CanLeave)
        {
            SceneManager.LoadScene(0);
        }
        Debug.Log(gameEnded);

        CurrentScorePlayer1.text = currentScore1.ToString();
        CurrentScorePlayer2.text = currentScore2.ToString();
    }

    public IEnumerator ShowScore()
    {
        gameEnded = true;

        normalHitText1.text = "" + normalHits1;
        missHitText1.text = "" + missedHits1;
        perfectHitText1.text = "" + perfectHits1;

        //Rank Calculation Player 1
        float totalHit1 = normalHits1 + perfectHits1;
        float percentHit1 = (totalHit1 / totalNotes) * 100f;
        string rankVal1 = "F";
        if (percentHit1 > 40)
        {
            rankVal1 = "D";
            if (percentHit1 > 55)
            {
                rankVal1 = "C";
                if (percentHit1 > 70)
                {
                    rankVal1 = "B";
                    if (percentHit1 > 85)
                    {
                        rankVal1 = "A";
                        if (percentHit1 > 95)
                        {
                            rankVal1 = "S";
                            if (percentHit1 > 99.9)
                            {
                                rankVal1 = "S+";
                            }
                        }
                    }
                }
            }
        }
        rankText1.text = rankVal1;
        finalScoreText1.text = currentScore1.ToString();

        normalHitText2.text = "" + normalHits2;
        missHitText2.text = "" + missedHits2;
        perfectHitText2.text = "" + perfectHits2;

        //Rank Calculation Player 2
        float totalHit2 = normalHits2 + perfectHits2;
        float percentHit2 = (totalHit2 / totalNotes) * 100f;

        string rankVal2 = "F";
        if (percentHit2 > 40f)
        {
            rankVal2 = "D";
            if (percentHit2 > 55f)
            {
                rankVal2 = "C";
                if (percentHit2 > 70f)
                {
                    rankVal2 = "B";
                    if (percentHit2 > 85f)
                    {
                        rankVal2 = "A";
                        if (percentHit2 > 95f)
                        {
                            rankVal2 = "S";
                            if (percentHit2 > 99.9f)
                            {
                                rankVal2 = "S+";
                            }
                        }
                    }
                }
            }
        }
        rankText2.text = rankVal2;
        finalScoreText2.text = currentScore2.ToString();

        if (abilities.LeftPlayer_Health.fillAmount < abilities.RightPlayer_Health.fillAmount)
        {
            //Right Player wins
            player2Wins.text = "Wins";
            player1Wins.text = "";
        }
        else if (abilities.LeftPlayer_Health.fillAmount > abilities.RightPlayer_Health.fillAmount)
        {
            //Left player wins
            player1Wins.text = "Wins";
            player2Wins.text = "";
        }
        else if (abilities.LeftPlayer_Health.fillAmount == abilities.RightPlayer_Health.fillAmount)
        {
            if (currentScore1 > currentScore2)
            {
                player1Wins.text = "Wins";
                player2Wins.text = "";
            }
            else if (currentScore1 < currentScore2)
            {
                player2Wins.text = "Wins";
                player1Wins.text = "";
            }
            else
            {
                player2Wins.text = "Tie";
                player1Wins.text = "Tie";
            }
        }
        int winnerScore;
        if (currentScore1 > currentScore2)
            winnerScore = currentScore1;
        else
            winnerScore = currentScore2;

        if (PlayerPrefs.GetInt("HighScore") < winnerScore)
            PlayerPrefs.SetInt("HighScore", winnerScore);

        if (PlayerPrefs.GetInt("HighScore") == null)
        {
            PlayerPrefs.SetInt("HighScore", winnerScore);
        }
        yield return new WaitForSeconds(3);
        ScoreBoard.SetTrigger("ShowBoard");
        Abillities.SetTrigger("RemoveAbilities");
        continueButton.SetTrigger("ShowUp");
        CanLeave = true;
    }


    //Player 1---------------------------------
    public void NoteHit1()
    {
        notesLeft1--;

        if (currentmultiplier1 - 1 < multiplierThresholds1.Length)
        {
            multiplierTracker1++;

            if (multiplierThresholds1[currentmultiplier1 - 1] <= multiplierTracker1)
            {
                multiplierTracker1 = 0;
                currentmultiplier1++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            LeftPlayer_Block.fillAmount += 0.05f * currentmultiplier1;
            LeftPlayer_Punch.fillAmount += 0.02f * currentmultiplier1;
            LeftPlayer_Kick.fillAmount += 0.01f * currentmultiplier1;
        }
    }

    public void NormalHit1()
    {
        NoteHit1();
        currentScore1 += scorePerNote * currentmultiplier1 * 2;
        normalHits1++;
        Debug.Log("NormalHit");
    }
    public void MissHit1()
    {
        missedHits1++;
        notesLeft1--;
        currentmultiplier1 = 1;
        multiplierTracker1 = 0;
    }
    public void PerfectHit1()
    {
        NoteHit1();
        currentScore1 += scorePerPerfectNote * currentmultiplier1 * 2;
        perfectHits1++;
    }

    //PLAYER 2-------------------------------
    public void NoteHit2()
    {
        notesLeft2--;
        if (currentmultiplier2 - 1 < multiplierThresholds2.Length)
        {
            multiplierTracker2++;

            if (multiplierThresholds2[currentmultiplier2 - 1] <= multiplierTracker2)
            {
                multiplierTracker2 = 0;
                currentmultiplier2++;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightPlayer_Block.fillAmount += 0.05f * currentmultiplier2;
            RightPlayer_Punch.fillAmount += 0.02f * currentmultiplier2;
            RightPlayer_Kick.fillAmount += 0.01f * currentmultiplier2;
        }
    }

    public void NormalHit2()
    {
        NoteHit2();
        currentScore2 += scorePerNote * currentmultiplier2 * 2;
        normalHits2++;
    }
    public void MissHit2()
    {
        missedHits2++;
        currentmultiplier2 = 1;
        multiplierTracker2 = 0;
        notesLeft2--;
    }
    public void PerfectHit2()
    {
        NoteHit2();
        currentScore2 += scorePerPerfectNote * currentmultiplier2 * 2;
        perfectHits2++;
    }
}

