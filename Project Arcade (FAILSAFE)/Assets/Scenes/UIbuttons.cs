using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class UIbuttons : MonoBehaviour
{
    public GameObject deathScreen;

    public bool paused = false;

    public EnemyController enemy;
    public PlayerController player;

    public float totalCoins;
    public bool isDead = false;
    public float coinsAfterPassedEnemy;
    public float totalCoinCurrency;

    public bool died1time = false;

    public float totalBlocksPassed;

    public Text countdown;
    public bool countdownEnded;
    public void Start()
    {
        StartCoroutine(TimeBetweenPause());

        totalCoins = PlayerPrefs.GetFloat("totalBalance");
        totalBlocksPassed = PlayerPrefs.GetFloat("totalBlocksPassed");
        player.GetComponent<AudioSource>().Play();
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            player.GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().Play();
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerController>().enabled = false;
            player.pauseMenu.SetActive(true);
            player.pauseButton.SetActive(false);
        }
        else
        {
            StartCoroutine(TimeBetweenPause());
            countdownEnded = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            player.pauseMenu.SetActive(false);
            player.pauseButton.SetActive(true);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isDead || countdownEnded)
            {
                Pause();
            }
        }
    }

    public void Death()
    {
        isDead = true;

        PlayerPrefs.SetInt("Highscore", enemy.highscore);
        PlayerPrefs.SetInt("totalBalance", player.totalCoins);

        deathScreen.SetActive(true);

        Time.timeScale = 0f;

        totalCoinCurrency = totalCoinCurrency + enemy.enemiesPassed - coinsAfterPassedEnemy;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator TimeBetweenPause()
    {
        player.GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0.01f;
        countdown.text = "3";
        yield return new WaitForSeconds(0.01f);
        countdown.text = "2";
        yield return new WaitForSeconds(0.01f);
        countdown.text = "1";
        yield return new WaitForSeconds(0.01f);
        countdown.text = "";
        Time.timeScale = 1;
        countdownEnded = true;
        player.GetComponent<PlayerController>().enabled = true;
        GetComponent<AudioSource>().Pause();
        StopCoroutine(TimeBetweenPause());
        player.GetComponent<AudioSource>().UnPause();
    }
}