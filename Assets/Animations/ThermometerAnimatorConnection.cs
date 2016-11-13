using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThermometerAnimatorConnection : MonoBehaviour {

    void Update() {
        GetComponent<Animator>().SetBool("HeadCheck", Thermometer.isOnHead);
        GetComponent<Animator>().SetBool("Fever", Mathf.Round(Thermometer.temperature) >= GameManager.parameters.feverTemperature);
        GetComponent<Animator>().SetBool("Hypothermia", Mathf.Round(Thermometer.temperature) <= GameManager.parameters.hypothermiaTemperature);
        GetComponent<Animator>().SetBool("Healthy", Mathf.Round(Thermometer.temperature) > GameManager.parameters.hypothermiaTemperature &&
                                                    Mathf.Round(Thermometer.temperature) < GameManager.parameters.feverTemperature);
    }
	
}
