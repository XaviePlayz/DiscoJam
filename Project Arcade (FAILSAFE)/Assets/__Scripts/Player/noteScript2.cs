using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class noteScript2 : MonoBehaviour
{
    public float beatTempo;

    bool canBePressed = false;
    public bool pressed = false;
    public KeyCode press_key;

    void Start()
    {
        beatTempo /= 60;
    }

    void Update()
    {
        if (GameManager.instance.GameStarted)
        {
            transform.position += new Vector3(0, beatTempo * 2 * Time.deltaTime, 0);
        }
        KeyPress();
    }

    void KeyPress()
    {
        if (Input.GetKeyDown(press_key))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                if (transform.position.y > GameManager.instance.minNormalClickHeight && transform.position.y < GameManager.instance.maxNormalClickHeight)
                {
                    if (transform.position.y > GameManager.instance.minPerfectClickHeight && transform.position.y < GameManager.instance.maxPerfectClickHeight)
                    {
                        GameManager.instance.PerfectHit2();
                        Instantiate(GameManager.instance.PerfectParticle, transform.position, GameManager.instance.PerfectParticle.transform.rotation);
                    }
                    else
                    {
                        GameManager.instance.NormalHit2();
                        Instantiate(GameManager.instance.NormalParticle, transform.position, GameManager.instance.NormalParticle.transform.rotation);
                    }
                }
                else
                {
                    GameManager.instance.MissHit2();
                    Instantiate(GameManager.instance.MissParticle, transform.position, GameManager.instance.MissParticle.transform.rotation);
                }
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            if (gameObject.activeInHierarchy)
            {
                canBePressed = false;
                gameObject.SetActive(false);
                GameManager.instance.MissHit2();
                Instantiate(GameManager.instance.MissParticle, transform.position, GameManager.instance.MissParticle.transform.rotation);
            }
        }
    }
}
