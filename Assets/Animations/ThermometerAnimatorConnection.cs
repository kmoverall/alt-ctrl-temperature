using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThermometerAnimatorConnection : MonoBehaviour {

    void Update() {
        GetComponent<Animator>().SetBool("HeadCheck", Thermometer.isOnHead);
    }
	
}
