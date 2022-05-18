using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public GameObject obj;
    public EnemyController enem;

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
            enem.Count();
        }
    }
}
