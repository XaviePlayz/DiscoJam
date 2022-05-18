using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScreen : MonoBehaviour
{
    Image screen;
    [SerializeField] [Range(0f, 100f)] float time;

    [SerializeField] Color[] colors;

    public int colorindex = 0;
    float t = 0;

    int len;

    private void Start()
    {
        screen = GetComponent<Image>();
        len = colors.Length;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        screen.color = Color.white;
        screen.material.color = Color.Lerp(screen.material.color, colors[colorindex], time * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, time * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            colorindex++;
            colorindex = (colorindex >= len) ? 0 : colorindex;
        }
    }
}
