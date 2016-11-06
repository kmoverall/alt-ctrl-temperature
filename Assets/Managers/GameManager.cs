/// Note: that the more namespaces we use the more loading this screen has to do
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager> {
    protected GameManager() { }
    
    GameParameters _parameters;
    public static GameParameters parameters { get { return Instance._parameters; } }

    void Awake() {
        _parameters = Resources.Load("GameParameterData") as GameParameters;
    }

    void Update() {

    }
}