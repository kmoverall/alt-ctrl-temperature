using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMainMenu : MonoBehaviour {

    public Animator momAnimator;

	public void ChooseFarenheit() {
        GameManager.unitSystem = UnitSystem.Imperial;
        GetComponent<Animator>().SetTrigger("Hide Menu");
        momAnimator.SetTrigger("Start Game");
    }

    public void ChooseCelsius() {
        GameManager.unitSystem = UnitSystem.Metric;
        GetComponent<Animator>().SetTrigger("Hide Menu");
        momAnimator.SetTrigger("Start Game");
    }

    public void Quit() {
        Application.Quit();
    }
}
