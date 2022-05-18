using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmPart : MonoBehaviour
{

    public KeyCode press_key;

    private SpriteRenderer Button;
    public Sprite default_image;
    public Sprite pressed_image;
    public bool pressed = false;



    void Start()
    {
        Button = GetComponent<SpriteRenderer>();   
    }
    void Update()
    {
        KeyPress();
    }

    void KeyPress()
    {
        if (Input.GetKeyDown(press_key))
        {
            Button.sprite = pressed_image;
            pressed = true;
        }


        if (Input.GetKeyUp(press_key))
        {
            Button.sprite = default_image;
            pressed = false;
        }

    }


}
