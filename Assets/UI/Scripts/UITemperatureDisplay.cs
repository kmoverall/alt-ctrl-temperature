﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Text))]
public class UITemperatureDisplay : MonoBehaviour {
	void Update () {
        GetComponent<Text>().text = Thermometer.displayTemperature;
	}
}
