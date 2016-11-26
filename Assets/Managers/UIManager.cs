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

    public static void FireMenuAnimation(string trigger) {
        Instance.mainMenu.GetComponent<Animator>().SetTrigger(trigger);
    }
}