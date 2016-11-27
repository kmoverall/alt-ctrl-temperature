/// Note: that the more namespaces we use the more loading this screen has to do
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class UIManager : Singleton<UIManager>
{
    protected UIManager() { }

    public GameObject mainMenu;
    public Text gameOverText;
    public Text gameOverSubText;

    public string loseString;
    public Color loseColor;
    public string winString;
    public Color winColor;

    public static void FireMenuAnimation(string trigger) {
        Instance.mainMenu.GetComponent<Animator>().SetTrigger(trigger);
    }

    public static void SetFinalUIText(bool success, string subText) {
        Instance.gameOverText.text = success ? Instance.winString : Instance.loseString;
        Instance.gameOverText.color = success ? Instance.winColor : Instance.loseColor;
        Instance.gameOverSubText.text = subText;
    }
}