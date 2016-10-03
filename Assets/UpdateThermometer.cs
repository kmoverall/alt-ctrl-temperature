using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Slider))]
public class UpdateThermometer : MonoBehaviour {
    public float minTemp;
    public float maxTemp;

    Slider slider;

	void Start () {
        slider = GetComponent<Slider>();
	}
	
	void Update () {
        slider.value = (Thermometer.temperature - minTemp) / (maxTemp - minTemp);
	}

    void OnValidate() {
        if (maxTemp <= minTemp) {
            maxTemp = minTemp + 0.01f;
        }
    }
}
