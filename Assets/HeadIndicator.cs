using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeadIndicator : MonoBehaviour {
	void Update () {
        GetComponent<Image>().color = Thermometer.isOnHead ? Color.green : Color.red;
	}
}
