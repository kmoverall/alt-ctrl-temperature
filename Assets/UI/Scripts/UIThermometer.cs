using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Slider))]
public class UIThermometer : MonoBehaviour {
    public float minTemp;
    public float maxTemp;
    public int smoothing = 30;
    
    public Image healthyLowIndicator;
    public Image healthyHighIndicator;

    Slider slider;

	void Start () {
        slider = GetComponent<Slider>();
        Thermometer.smoothing = smoothing;

        //Determine indicator position
        slider.value = (GameManager.parameters.coldTemperature - minTemp) / (maxTemp - minTemp);
        Vector3 indicatorPos = Vector3.zero;
        indicatorPos.x = healthyLowIndicator.rectTransform.position.x;
        indicatorPos.y = slider.handleRect.position.y;
        healthyLowIndicator.rectTransform.position = indicatorPos;

        slider.value = (GameManager.parameters.feverTemperature - minTemp) / (maxTemp - minTemp);
        indicatorPos = Vector3.zero;
        indicatorPos.x = healthyHighIndicator.rectTransform.position.x;
        indicatorPos.y = slider.handleRect.position.y;
        healthyHighIndicator.rectTransform.position = indicatorPos;
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
