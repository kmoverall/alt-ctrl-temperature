/// Note: that the more namespaces we use the more loading this screen has to do
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

public class SerialInputManager : Singleton<SerialInputManager> {
    protected SerialInputManager() { }

    string[] _serialData;
    public static string[] serialData { get { return Instance._serialData; } }

    SerialPort _serial;
    public static SerialPort serial { get { return Instance._serial; } }
    
    string portName = "COM3";

    void Awake() {
        Instance._serial = new SerialPort();
        Instance.portName = portName;

        //Serial Port Setup
        serial.PortName = portName;
        serial.Parity = Parity.None;
        serial.BaudRate = 9600;
        serial.DataBits = 8;
        serial.StopBits = StopBits.One;
        serial.ReadTimeout = 5;
        serial.Handshake = Handshake.None;
        serial.RtsEnable = true;
        serial.DtrEnable = true;
        serial.Open();
    }

    void Update() {
        try {
            string line = serial.ReadLine();
            Instance._serialData = line.Split(' ');
        }
        catch { }
    }

    /*void OnDisable() {
        serial.Close();
    }

    protected override void OnDestroy() {
        serial.Close();
        base.OnDestroy();
    }

    protected override void OnApplicationQuit() {
        serial.Close();
        base.OnApplicationQuit();
    }*/
}