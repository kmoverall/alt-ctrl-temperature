using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMainMenu : MonoBehaviour {

    public Animator momAnimator;
    public GameObject lunch;

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

    public void Restart() {
        GetComponent<Animator>().SetTrigger("Hide Menu");
        CinematicManager.Stop();
        momAnimator.SetTrigger("Restart");
        momAnimator.SetInteger("Lunches Made", 0);
        momAnimator.SetInteger("PossibleTurnIndex", 0);
        momAnimator.SetTrigger("Start Game");
        momAnimator.GetComponent<TurnTimingSelector>().GenerateNewTimings();
        momAnimator.GetComponent<LunchHandler>().Restart();
    }

    public void MainMenu() {
        GetComponent<Animator>().SetTrigger("Show Main Menu");
        CinematicManager.Stop();
        momAnimator.SetTrigger("Restart");
        momAnimator.SetInteger("Lunches Made", 0);
        momAnimator.SetInteger("PossibleTurnIndex", 0);
        momAnimator.GetComponent<TurnTimingSelector>().GenerateNewTimings();
        momAnimator.GetComponent<LunchHandler>().Restart();
    }

    public void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
