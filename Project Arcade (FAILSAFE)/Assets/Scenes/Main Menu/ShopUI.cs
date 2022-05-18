using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopUI : MonoBehaviour
{
    public static int myPlayerSkin;
    public Text coinText;
    private int totalCoins;

    public List<Button> buttons;

    public Color ifSelected;
    public Color notSelected;

    public void Start()
    {
        myPlayerSkin = PlayerPrefs.GetInt("playerSkin");
        totalCoins = PlayerPrefs.GetInt("totalBalance");
        coinText.text = totalCoins.ToString();
    }

    public void Update()
    {
        coinText.text = totalCoins.ToString();

        if (myPlayerSkin == 0)
        {
            buttons[0].image.color = ifSelected;
            buttons[1].image.color = notSelected;
            buttons[2].image.color = notSelected;
            buttons[3].image.color = notSelected;
        }
        else if (myPlayerSkin == 1)
        {
            buttons[0].image.color = notSelected;
            buttons[1].image.color = ifSelected;
            buttons[2].image.color = notSelected;
            buttons[3].image.color = notSelected;
        }
        else if (myPlayerSkin == 2)
        {
            buttons[0].image.color = notSelected;
            buttons[1].image.color = notSelected;
            buttons[2].image.color = ifSelected;
            buttons[3].image.color = notSelected;
        }
        else if (myPlayerSkin == 3)
        {
            buttons[0].image.color = notSelected;
            buttons[1].image.color = notSelected;
            buttons[2].image.color = notSelected;
            buttons[3].image.color = ifSelected;
        }
    }

    public void Skin1()
    {
        myPlayerSkin = 0;
        PlayerPrefs.SetInt("playerSkin", myPlayerSkin);
    }
    public void Skin2()
    {
        myPlayerSkin = 1;
        PlayerPrefs.SetInt("playerSkin", myPlayerSkin);
    }
    public void Skin3()
    {
        myPlayerSkin = 2;
        PlayerPrefs.SetInt("playerSkin", myPlayerSkin);
    }
    public void Skin4()
    {
        myPlayerSkin = 3;
        PlayerPrefs.SetInt("playerSkin", myPlayerSkin);
    }
}
