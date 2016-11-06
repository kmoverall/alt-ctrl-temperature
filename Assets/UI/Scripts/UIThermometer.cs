using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Slider))]
public class UIThermometer : MonoBehaviour {
    public float minTemp;
    public float maxTemp;
    public int smoothing = 30;
    
    public Image healthyIndicator;

    Slider slider;

	void Start () {
        slider = GetComponent<Slider>();
        Thermometer.smoothing = smoothing;

        //Determine indicator position
        slider.value = (GameManager.parameters.healthyTemperature - minTemp) / (maxTemp - minTemp);
        Vector3 indicatorPos = Vector3.zero;
        indicatorPos.x = healthyIndicator.rectTransform.position.x;
        indicatorPos.y = slider.handleRect.position.y;
        healthyIndicator.rectTransform.position = indicatorPos;
    }
	
	void Update () {
        slider.value = (Thermometer.temperature - minTemp) / (maxTemp - minTemp);
	}

    void OnValidate() {
        if (maxTemp <= minTemp) {
            maxTemp = minTemp + 1f;
        }

        if (smoothing < 1) {
            smoothing = 1;
        }
    }
}
