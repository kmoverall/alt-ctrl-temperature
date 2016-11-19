using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class Thermometer : Singleton<Thermometer> {
    protected Thermometer() { }

    float _temp = 60;
    public static float temperature { get { return !DebugManager.DebugMode ? Instance._temp : DebugManager.temperature; } }

    List<float> _record = new List<float>();
    int _smoothing = 30;
    public static int smoothing { get { return Instance._smoothing; } set { Instance._smoothing = value; } }
    
    bool _isOnHead = false;
    public static bool isOnHead { get { return !DebugManager.DebugMode ? Instance._isOnHead : DebugManager.isOnHead; } }

    public static string displayTemperature { 
        get { 
            float t = GameManager.unitSystem == UnitSystem.Imperial ? temperature : (temperature - 32) / 1.8f;
            return Mathf.Round(t).ToString() + '\u00B0';
        }
    }
    
    void Update() {
        if (!DebugManager.DebugMode) {
            //Get Temperature Data
            if (SerialInputManager.serialData == null || SerialInputManager.serialData.Length == 0) {
                return;
            }

            float t = Convert.ToInt32(SerialInputManager.serialData[0]);
            //Convert raw reading to temperature
            t = t / 128f;
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

            //Logic for head sensor is reversed
            _isOnHead = SerialInputManager.serialData[1] == "0";
        }
    }
}
