using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject settingsScreen, mainScreen, creditsScreen, levelScreen, difficultyScreen;
    public GameObject settingsButton, menuButton, creditsButton, levelButton, difficultyButton;
    public static SceneManagerScript instance;

    public Slider AudioMusic;
    public List<AudioSource> musics;
    public static float AudioVolume = 0.5f;
    public TextMeshProUGUI HighScoreText1;
    public TextMeshProUGUI HighScoreText2;

    public int difficultyIndex;
    private int highScore;
    public void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        instance = this;
        AudioMusic.value = AudioMusic.value;
        for (int i = 0; i < musics.Count; i++)
        {
            musics[i].volume = AudioMusic.value;
        }
        HighScoreText1.text = "HighScore : " + highScore;
        HighScoreText2.text = "HighScore : " + highScore;
    }
    public void Song1_Easy()
    {
        difficultyIndex = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    public void Song1_Normal()
    {
        difficultyIndex = 2;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    public void Song1_Hard()
    {
        difficultyIndex = 3;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }
    public void Update()
    {

        if (settingsScreen.activeInHierarchy)
        {
            for (int i = 0; i < musics.Count; i++)
            {
                musics[i].volume = AudioMusic.value;
                AudioVolume = AudioMusic.value;
            }
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        settingsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void HideSettings()
    {
        settingsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
    public void ShowDifficulty()
    {
        difficultyScreen.SetActive(true);
        levelScreen.SetActive(false);
    }
    public void HideDifficulty()
    {
        difficultyScreen.SetActive(false);
        levelScreen.SetActive(true);
    }
    public void ShowCredits()
    {
        creditsScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void HideCredits()
    {
        creditsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void ShowLevelSelect()
    {
        levelScreen.SetActive(true);
        mainScreen.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    public void HideLevelSelect()
    {
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }
}
