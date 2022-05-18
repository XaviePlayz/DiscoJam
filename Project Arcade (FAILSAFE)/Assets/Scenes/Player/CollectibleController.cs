using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public GameObject coin;
    public GameObject healthBoost;
    public GameObject speedBoost;
    public GameObject slowdownTime;

    public float spawnTime;
    public float spawnPerblock;
    public float speedbuildupPerblock;
    public float maxSpeed;
    public float maxBuildup;

    public float buildup;
    private float spawn1;
    private float spawn2;
    private float timer;
    private float randomCollectible;

    public UIbuttons uibut;

    public bool running = true;

    public void Update()
    {
        if (spawn1 > 0)
        {
            spawn2 = -4f;
        }
        if (spawn1 < 0)
        {
            spawn2 = 4f;
        }
        if (spawn1 == 0)
        {
            spawn2 = 0f;
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

                CollectibleSpawn();
                timer = 0f;

            }
        }
    }

    public void CollectibleSpawn()
    {
        spawn1 = Random.Range(-1f, 1f);
        randomCollectible = Random.Range(0, 4);

        if (running == true)
        {
            if (uibut.died1time == true)
            {
                if (randomCollectible == 0)
                {
                    Instantiate(coin, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
                else if (randomCollectible == 1)
                {
                    Instantiate(healthBoost, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
                else if (randomCollectible == 2)
                {
                    if (spawn2 == 4f)
                    {
                        Instantiate(coin, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(speedBoost, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                    }
                }
                else if (randomCollectible == 3)
                {
                    Instantiate(slowdownTime, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
            }
            else
            {
                if (randomCollectible == 0)
                {
                    Instantiate(coin, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
                else if (randomCollectible == 1)
                {
                    Instantiate(healthBoost, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
                else if (randomCollectible == 2)
                {
                    if (spawn2 == 4f)
                    {
                        Instantiate(coin, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(speedBoost, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                    }
                }
                else if (randomCollectible == 3)
                {
                    Instantiate(slowdownTime, new Vector3(spawn2, 6f, 0f), Quaternion.identity);
                }
            }
        }
    }
    public void TimeScale()
    {
        running = false;
    }
}
