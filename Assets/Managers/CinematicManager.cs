using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class CinematicManager : Singleton<CinematicManager> {
    protected CinematicManager() { }

    JSONObject cinematicData;
    public RectTransform speechBubble;
    TypeOutText speechText;
    public float interSpeechDelay;

    void Start() {
        TextAsset jsonText = Resources.Load("Cinematics") as TextAsset;
        Instance.cinematicData = JSONObject.Create(jsonText.text);
        Instance.speechText = Instance.speechBubble.GetComponentInChildren<TypeOutText>();
        Play("start");
    }

    void Update() {

    }

    public static void Play(string name) {
        JSONObject cinematicSequence = Instance.cinematicData.GetField(name);
        Instance.StartCoroutine(Instance.PlayTextSequence(cinematicSequence));
    }

    IEnumerator PlayTextSequence(JSONObject cinematicSequence) {
        speechBubble.GetComponent<Animator>().SetTrigger("Show");
        while(!speechBubble.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shown")) {
            yield return null;
        }

        for (int i = 0; i < cinematicSequence.Count; i++) {
            //Parse Dialogue String
            string dialogue = cinematicSequence[i].str;
            dialogue = dialogue.Replace("\\n", "\n");

            yield return StartCoroutine(speechText.TypeText(dialogue));
            yield return new WaitForSeconds(interSpeechDelay);
        }
        speechBubble.GetComponent<Animator>().SetTrigger("Hide");
    }
}
