﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThermometerAnimatorConnection : MonoBehaviour {

    void Update() {
        GetComponent<Animator>().SetBool("HeadCheck", Thermometer.isOnHead);
        GetComponent<Animator>().SetBool("Fever", Mathf.Round(Thermometer.temperature) >= GameManager.parameters.feverTemperature);
        GetComponent<Animator>().SetBool("Too Cold", Mathf.Round(Thermometer.temperature) <= GameManager.parameters.coldTemperature &&
                                                     Mathf.Round(Thermometer.temperature) > GameManager.parameters.muchTooColdTemperature);
        GetComponent<Animator>().SetBool("Much Too Cold", Mathf.Round(Thermometer.temperature) <= GameManager.parameters.muchTooColdTemperature);
        GetComponent<Animator>().SetBool("Healthy", Mathf.Round(Thermometer.temperature) > GameManager.parameters.coldTemperature &&
                                                    Mathf.Round(Thermometer.temperature) < GameManager.parameters.feverTemperature);
    }
	
}
