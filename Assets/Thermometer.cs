using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public enum UnitSystem { Imperial, Metric }
public class Thermometer : MonoBehaviour {
    public static SerialPort serial1;
    public static string portName = "COM3";
    static float _temp;
    public static float temperature { get { return _temp; } }
    public static UnitSystem units = UnitSystem.Imperial;
    static List<float> _record;
    public static int smoothing = 3;

    // Use this for initialization
    void Start() {
        _record = new List<float>();

        //Serial Port Setup
        serial1 = new SerialPort();
        serial1.PortName = portName;
        serial1.Parity = Parity.None;
        serial1.BaudRate = 9600;
        serial1.DataBits = 8;
        serial1.StopBits = StopBits.One;
        serial1.ReadTimeout = 5;
        serial1.Handshake = Handshake.None;
        serial1.RtsEnable = true;
        serial1.DtrEnable = true;
        serial1.Open();
    }

    // Update is called once per frame
    void Update() {
        float t = 0;
        try {
            string line = serial1.ReadLine();
            t = Convert.ToInt32(line);
            //Convert raw reading to temperature
            t = t/128f;
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
        }
        catch { }
    }

    void OnDisable() {
        serial1.Close();
    }

    void OnDestroy() {
        serial1.Close();
    }

    void OnApplicationQuit() {
        serial1.Close();
    }


}
