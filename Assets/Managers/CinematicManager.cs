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
    public AudioSource musicSource;

    bool _isPlaying;
    public static bool isPlaying { get { return Instance._isPlaying; } }

    static string _currentDialogue;

    void Start() {
        TextAsset jsonText = Resources.Load("Cinematics") as TextAsset;
        Instance.cinematicData = JSONObject.Create(jsonText.text);
        Instance.speechText = Instance.speechBubble.GetComponentInChildren<TypeOutText>();
    }

    void Update() {

    }

    public static void PlayMusic(AudioClip music) 
    {
       Instance.musicSource.clip = music;
       Instance.musicSource.Play();
    }

    public static void Play(string name) {
        if (_currentDialogue != name) {
            _currentDialogue = name;
            Instance.StopAllCoroutines();
            JSONObject cinematicSequence = Instance.cinematicData.GetField(name);
            Instance.StartCoroutine(Instance.PlayTextSequence(cinematicSequence));
        }
    }

    public static void Stop() {
        Instance.StopAllCoroutines();
        Instance.StartCoroutine(Instance.StopTextSequence());
    }

    IEnumerator PlayTextSequence(JSONObject cinematicSequence) {
        if (_isPlaying) {
            speechText.Cancel();
            speechBubble.GetComponent<Animator>().SetTrigger("Hide");
            while (!speechBubble.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hidden")) {
                yield return null;
            }
        }
        else {
            _isPlaying = true;
        }

        speechBubble.GetComponent<Animator>().SetTrigger("Show");
        while(!speechBubble.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shown")) {
            yield return null;
        }

        for (int i = 0; i < cinematicSequence.Count; i++) {
            //Parse Dialogue String
            string dialogue = cinematicSequence[i].str;
            dialogue = dialogue.Replace("\\n", "\n");

            dialogue = dialogue.Replace("#TEMPERATURE#", Thermometer.displayTemperature);

            yield return StartCoroutine(speechText.TypeText(dialogue));
            yield return new WaitForSeconds(interSpeechDelay);
        }
        
        speechBubble.GetComponent<Animator>().SetTrigger("Hide");
        while (!speechBubble.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hidden")) {
            yield return null;
        }
        _isPlaying = false;
        _currentDialogue = "";
    }

    IEnumerator StopTextSequence() {
        speechBubble.GetComponent<Animator>().SetTrigger("Hide");
        while (!speechBubble.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hidden"))
        {
            yield return null;
        }
        _isPlaying = false;
        _currentDialogue = "";
    }
}
