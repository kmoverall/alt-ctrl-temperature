using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CinematicManager : Singleton<CinematicManager> {
    protected CinematicManager() { }

    void Start() {

    }

    void Update() {

    }

    public static void Play(string name) {
        Debug.Log(name);
    }
}
