using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject obj;
    public EnemyController enem;
    public PlayerController player;

    public bool isPaused;

    public void Update()
    {
        if (!isPaused)
        {
            transform.Translate(Vector3.down * enem.buildup * Time.deltaTime);
        }

        if (obj.transform.position.y <= -6)
        {
            Destroy(obj, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies")
        {
            Destroy(collision.gameObject);
        }

    }
}