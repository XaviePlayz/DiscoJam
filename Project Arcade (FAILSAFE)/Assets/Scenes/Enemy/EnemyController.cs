using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;

    public float spawnTime;
    public float spawnPerblock;
    public float speedbuildupPerblock;
    public float maxSpeed;
    public float maxBuildup;

    public int points;
    public int highscore;

    public Text countText;
    public Text highText;

    public float buildup;
    private float spawn1;
    private float spawn2;
    private float timer;

    public UIbuttons uibut;
    public PlayerController player;

    public float enemiesPassed;

    public bool running = true;

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highText.text = "Highscore:" + highscore.ToString();
    }

    public void Update()
    {
        if (spawn1 >= 0)
        {
            spawn2 = -4.5f;
        }
        if (spawn1 <= 0)
        {
            spawn2 = 4.5f;
        }

        if (running == true)
        {
            timer += 1 * Time.deltaTime;

            if (timer >= spawnTime)
            {
                if (timer >= maxSpeed)
                {
                    spawnTime -= spawnPerblock;
                }
                if (buildup <= maxBuildup)
                {
                    buildup += speedbuildupPerblock;
                }

                EnemySpawn();
                timer = 0f;

            }
        }
    }

    public void EnemySpawn()
    {

        spawn1 = Random.Range(-1f, 1f);

        if (running == true)
        {
            if (uibut.died1time == true)
            {
                Instantiate(enemy2, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
            }
        }
    }

    public void Count()
    {
        points++;

        if (points >= highscore || points == highscore)
        {
            highscore = points;
        }

        countText.text = "Score: " + points.ToString();
        highText.text = "Highscore:" + highscore.ToString();

        enemiesPassed++;
    }

    public void TimeScale()
    {
        running = false;
    }
}
