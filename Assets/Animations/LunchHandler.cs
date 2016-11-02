using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LunchHandler : MonoBehaviour {

    public List<SpriteRenderer> lunchItems;

    public int[] lunchAnimOrder;
    public string[] animTriggers;
    static int currentIndex = 0;

    public void AdvanceAnimation() {
        if (currentIndex < lunchAnimOrder.Length) {
            SendItemAnimTrigger(lunchAnimOrder[currentIndex], animTriggers[currentIndex]);
            currentIndex++;
        }
    }

    void SendItemAnimTrigger(int index, string triggerName) {
        Debug.Log("Setting Trigger " + triggerName + " for " + lunchItems[index].name);
        lunchItems[index].GetComponent<Animator>().SetTrigger(triggerName);
    }

    void OnValidate() {
        if (lunchAnimOrder.Length != animTriggers.Length) {
            Array.Resize(ref animTriggers, lunchAnimOrder.Length);
        }
    }
}
