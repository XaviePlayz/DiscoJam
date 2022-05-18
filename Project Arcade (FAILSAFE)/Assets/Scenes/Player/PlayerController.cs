using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject obj;
    public Transform player;
    public SpriteRenderer sprite;
    public UIbuttons uibuttons;
    public GameObject pauseButton;
    public GameObject pauseMenu;

    public AudioSource gameOverSound;
    public Animator animator;

    public int multiplier;
    public int totalCoins;
    public Text coinText;

    public bool isRight = true;
    public bool isLeft = false;

    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        ShopUI.myPlayerSkin = PlayerPrefs.GetInt("playerSkin");

        //Player Skins
        if (ShopUI.myPlayerSkin == 0)
        {
            sprite.color = new Color(255, 255, 255, 255);
            Debug.Log("White");
        }
        else if (ShopUI.myPlayerSkin == 1)
        {
            sprite.color = new Color(212, 13, 25, 255);
            Debug.Log("Red");
        }
        else if (ShopUI.myPlayerSkin == 2)
        {
            sprite.color = new Color(13, 137, 212, 255);
            Debug.Log("Blue");
        }
        else if (ShopUI.myPlayerSkin == 3)
        {
            sprite.color = new Color(248, 242, 0, 255);
            Debug.Log("Yellow");
        }
    }
    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        totalCoins = PlayerPrefs.GetInt("totalBalance");
        coinText.text = "Coins:" + totalCoins.ToString();
    }
    public void Update()
    {
        coinText.text = "Coins:" + totalCoins.ToString();

        if (Input.GetKeyDown(KeyCode.D) && isLeft || Input.GetKeyDown(KeyCode.RightArrow) && isLeft)
        {
            isRight = false;
            player.transform.position = new Vector3(4, player.position.y, player.position.z);
            animator.SetTrigger("IsJumpingRight");
        }

        if (Input.GetKeyDown(KeyCode.A) && isRight || Input.GetKeyDown(KeyCode.LeftArrow) && isRight)
        {
            isLeft = false;
            player.transform.position = new Vector3(-4, player.position.y, player.position.z);
            animator.SetTrigger("IsJumpingLeft");
        }

        if (obj.transform.position.x == -4)
        {
            isLeft = true;
            isRight = false;
        }
        if (obj.transform.position.x == 4)
        {
            isRight = true;
            isLeft = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            GetComponent<AudioSource>().Stop();
            gameOverSound.Play();
            pauseButton.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            uibuttons.Death();
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            totalCoins++;
        }

        if (collision.tag == "Health Boost")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Speed Boost")
        {
            Destroy(collision.gameObject);
            if (isLeft)
            {
                animator.SetTrigger("SpeedBoostLeft");
            }
            if (isRight)
            {
                animator.SetTrigger("SpeedBoostRight");
            }
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(SpeedBoost());
        }

        if (collision.tag == "Timer")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = true;
        StopCoroutine(Timer());
    }

    IEnumerator SpeedBoost()
    {
        Time.timeScale = 4f;
        yield return new WaitForSeconds(8f);
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Collider2D>().enabled = true;
        StopCoroutine(SpeedBoost());
    }
}

