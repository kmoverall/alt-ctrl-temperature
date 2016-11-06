using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public enum UnitSystem { Imperial, Metric }

public class Thermometer : Singleton<Thermometer> {
    protected Thermometer() { }

    float _temp = 60;
    public static float temperature { get { return Instance._temp; } }

    UnitSystem _units = UnitSystem.Imperial;
    public static UnitSystem units { get { return Instance._units; } }

    List<float> _record = new List<float>();
    int _smoothing = 30;
    public static int smoothing { get { return Instance._smoothing; } set { Instance._smoothing = value; } }
    
    bool _isOnHead = false;
    public static bool isOnHead { get { return Instance._isOnHead; } }
    
    void Update() {

        //Get Temperature Data
        if (SerialInputManager.serialData == null || SerialInputManager.serialData.Length == 0) {
            return;
        }

        float t = Convert.ToInt32(SerialInputManager.serialData[0]);
        //Convert raw reading to temperature
        t = t / 128f;
        if (units == UnitSystem.Imperial)
            t = t * 1.8f + 32;

        //Add new temperature to temperature record
        if (_record.Count == smoothing) {
            _record.RemoveAt(0);
        }
        _record.Add(t);

        //Take average of past several temperatures
        _temp = 0;
        foreach (float f in _record) {
            _temp += f;
        }
        _temp /= _record.Count;

        //Get Placement Data
        if (SerialInputManager.serialData.Length == 1) {
            return;
        }

        _isOnHead = SerialInputManager.serialData[1] == "1";
    }
}
