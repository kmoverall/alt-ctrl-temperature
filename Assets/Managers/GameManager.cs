/// Note: that the more namespaces we use the more loading this screen has to do
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public enum UnitSystem { Imperial, Metric }
public enum Gender { Male, Female }

public class GameManager : Singleton<GameManager> {
    protected GameManager() { }
    
    GameParameters _parameters;
    public static GameParameters parameters { get { return Instance._parameters; } }

    UnitSystem _unitSystem;
    public static UnitSystem unitSystem { get { return Instance._unitSystem; } }

    Gender _playerGender;
    public static Gender playerGender { get { return Instance._playerGender; } }

    void Awake() {
        _parameters = Resources.Load("GameParameterData") as GameParameters;
    }
}