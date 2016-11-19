using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugManager : Singleton<DebugManager> {
    protected DebugManager() { }

    public bool debugMode = false;
    public static bool DebugMode { get { return Instance.debugMode; } }

    public bool _isOnHead = false;
    public static bool isOnHead { get { return Instance._isOnHead; } }

    public float _temperature = 90;
    public static float temperature { get { return Instance._temperature;  } }

    [Range(0, 8)]
    public float debugTimeScale = 1;
    public static float TimeScale { get { return Instance.debugTimeScale; } }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.BackQuote)) {
            debugMode = true;
        }

        if (debugMode) {
            if (Input.GetKeyDown(KeyCode.KeypadPlus)) {
                _temperature++;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadMinus)) {
                _temperature--;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                _isOnHead = !_isOnHead;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                debugTimeScale *= 2;
                debugTimeScale = Mathf.Min(8, debugTimeScale);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                debugTimeScale /= 2;
            }
            Time.timeScale = debugTimeScale;
        }
	}
}
