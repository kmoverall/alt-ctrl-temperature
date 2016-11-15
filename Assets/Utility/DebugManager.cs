using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugManager : Singleton<DebugManager> {
    protected DebugManager() { }

    public bool debugMode = false;
    public static bool DebugMode { get { return Instance.debugMode; } }

    [Range(0, 8)]
    public float debugTimeScale = 1;
    public static float TimeScale { get { return Instance.debugTimeScale; } }
	
	void Update () {
        if (debugMode)
            Time.timeScale = debugTimeScale;
	}
}
