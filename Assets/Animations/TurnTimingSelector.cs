using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnTimingSelector : MonoBehaviour {

    [HideInInspector]
    public List<int> turnTimings;

    public int totalTurnTimes;
    public int minTurns;
    public int maxTurns;

	void Start () {
        GenerateNewTimings();
    }

    public void GenerateNewTimings() 
    {
        turnTimings = new List<int>();

        int numberOfTurns = Random.Range(minTurns, maxTurns);
        while (turnTimings.Count < numberOfTurns) 
        {
            int newTurn = Random.Range(0, totalTurnTimes - 1);
            if (!turnTimings.Contains(newTurn))
                turnTimings.Add(newTurn);
        }
    }
}
