using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartCountdownScript : MonoBehaviour
{
    [Header("Time Value")]
    public float timeValue;
    private TextMeshProUGUI timeText;
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //Start Countdown
        timeText.text = "" + Mathf.Round(timeValue);

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if (timeValue == 0)
        {
            GameManager.instance.GameStarted = true;
            Destroy(gameObject);
        }
    }
}
