using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class CinematicManager : Singleton<CinematicManager> {
    protected CinematicManager() { }

    JSONObject cinematicData;
    Text speechBubble;

    void Start() {
        TextAsset jsonText = Resources.Load("Cinematics") as TextAsset;
        Instance.cinematicData = JSONObject.Create(jsonText.text);
    }

    void Update() {

    }

    public static void Play(string name) {
        Debug.Log(name);
    }
}
