using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameParameters", menuName = "Data/Game Parameters", order = 90)]
public class GameParameters : ScriptableObject {
    public float healthyTemperature;
    public float feverTemperature;
    public float coldTemperature;
    public float muchTooColdTemperature;
    public float dangerTemperature;
    public float muchTooHotTemperature;
}