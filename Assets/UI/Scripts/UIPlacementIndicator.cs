using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIPlacementIndicator : MonoBehaviour {
	void Update () {
        GetComponent<Image>().enabled = DebugManager.DebugMode;
        GetComponent<Image>().color = Thermometer.isOnHead ? Color.green : Color.red;
	}
}
