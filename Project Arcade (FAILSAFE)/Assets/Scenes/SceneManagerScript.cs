using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript instance;

    [Header("Scenes")]
    public GameObject play;
    public GameObject settings, shop, quit;

    [Header("Buttons")]
    public Button playButton;
    public Button shopButton, settingsButton, quitButton;

    [Header("Animations")]
    public Animator playScreen;
    public Animator shopScreen, settingsScreen, quitScreen;

    [Header("Settings")]
    public Slider AudioMusic;
    public List<AudioSource> musics;
    public static float AudioVolume = 0.5f;

    public Text SaveText;
    public void Start()
    {
        AudioMusic.value = PlayerPrefs.GetFloat("Volume");

        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        instance = this;
        AudioMusic.value = AudioMusic.value;
        for (int i = 0; i < musics.Count; i++)
        {
            musics[i].volume = AudioMusic.value;
        }
    }
    public void Update()
    {
        if (settings.activeInHierarchy)
        {
            for (int i = 0; i < musics.Count; i++)
            {
                musics[i].volume = AudioMusic.value;
                AudioVolume = AudioMusic.value;
            }
        }

        if (Input.GetKey(KeyCode.Delete))
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            SaveText.text = "Save";
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", AudioMusic.value);
        SaveText.text = "Saved";
    }
    public void PlaySingleplayer()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ReturnToMenu()
    {
        play.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
    }

    public void Play()
    {
        if (play.activeInHierarchy)
        {
            playScreen.SetTrigger("Close");
            StartCoroutine(PlayClosing());
        }
        else if (shop.activeInHierarchy)
        {
            shopScreen.SetTrigger("Close");
            StartCoroutine(PlayClosing());
        }
        else if (settings.activeInHierarchy)
        {
            settingsScreen.SetTrigger("Close");
            StartCoroutine(PlayClosing());
        }
        else if (quit.activeInHierarchy)
        {
            quitScreen.SetTrigger("Close");
            StartCoroutine(PlayClosing());
        }
        else
        {
            play.SetActive(true);
            shop.SetActive(false);
            settings.SetActive(false);
            quit.SetActive(false);
        }
    }

    public void Shop()
    {
        if (shop.activeInHierarchy)
        {
            shopScreen.SetTrigger("Close");
            StartCoroutine(ShopClosing());
        }
        else if (play.activeInHierarchy)
        {
            playScreen.SetTrigger("Close");
            StartCoroutine(ShopClosing());
        }
        else if (settings.activeInHierarchy)
        {
            settingsScreen.SetTrigger("Close");
            StartCoroutine(ShopClosing());
        }
        else if (quit.activeInHierarchy)
        {
            quitScreen.SetTrigger("Close");
            StartCoroutine(ShopClosing());
        }
        else
        {
            play.SetActive(false);
            shop.SetActive(true);
            settings.SetActive(false);
            quit.SetActive(false);
        }
    }

    public void Settings()
    {
        if (settings.activeInHierarchy)
        {
            settingsScreen.SetTrigger("Close");
            StartCoroutine(SettingsClosing());
        }
        else if (play.activeInHierarchy)
        {
            playScreen.SetTrigger("Close");
            StartCoroutine(SettingsClosing());
        }
        else if (shop.activeInHierarchy)
        {
            shopScreen.SetTrigger("Close");
            StartCoroutine(SettingsClosing());
        }
        else if (quit.activeInHierarchy)
        {
            quitScreen.SetTrigger("Close");
            StartCoroutine(SettingsClosing());
        }
        else
        {
            play.SetActive(false);
            shop.SetActive(false);
            settings.SetActive(true);
            quit.SetActive(false);
        }
    }

    public void PressQuit()
    {
        if (quit.activeInHierarchy)
        {
            quitScreen.SetTrigger("Close");
            StartCoroutine(QuitClosing());
        }
        else if (play.activeInHierarchy)
        {
            playScreen.SetTrigger("Close");
            StartCoroutine(QuitClosing());
        }
        else if (shop.activeInHierarchy)
        {
            shopScreen.SetTrigger("Close");
            StartCoroutine(QuitClosing());
        }
        else if (settings.activeInHierarchy)
        {
            settingsScreen.SetTrigger("Close");
            StartCoroutine(QuitClosing());
        }
        else
        {
            play.SetActive(false);
            shop.SetActive(false);
            settings.SetActive(false);
            quit.SetActive(true);
        }
    }

    public void DontQuit()
    {
        quitScreen.SetTrigger("Close");
        StartCoroutine(QuitClosing());
    }

    public void Quit()
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    IEnumerator PlayClosing()
    {
        yield return new WaitForSeconds(0.6f);
        play.SetActive(true);
        settings.SetActive(false);
        shop.SetActive(false);
        quit.SetActive(false);
        StopCoroutine(PlayClosing());
    }

    IEnumerator ShopClosing()
    {
        yield return new WaitForSeconds(0.6f);
        play.SetActive(false);
        shop.SetActive(true);
        settings.SetActive(false);
        quit.SetActive(false);
        StopCoroutine(ShopClosing());
    }

    IEnumerator SettingsClosing()
    {
        yield return new WaitForSeconds(0.6f);
        play.SetActive(false);
        shop.SetActive(false);
        settings.SetActive(true);
        quit.SetActive(false);
        StopCoroutine(SettingsClosing());
    }

    IEnumerator QuitClosing()
    {
        yield return new WaitForSeconds(0.6f);
        play.SetActive(false);
        shop.SetActive(false);
        quit.SetActive(true);
        settings.SetActive(false);
        StopCoroutine(QuitClosing());
    }
}
