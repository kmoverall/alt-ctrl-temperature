using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeOutText : MonoBehaviour {

    Text textObject;
    string stringToPrint = "";
    float baseTalkSFXPitch = 0;

    public float typingSpeed = 30;
    public float talkSFXPitchVariance = 0.1f;
    [HideInInspector]
    public bool isFinished = false;

    void OnEnable() {
        PrepText();
    }

    public void PrepText() {
        textObject = GetComponent<Text>();
        textObject.text = "";
    }
    
    public void StartTyping(string textToType) {
        StartCoroutine(TypeText(textToType));
    }

    public void Interrupt() {
        StopCoroutine("TypeText");
        textObject.text = stringToPrint;
        isFinished = true;
    }

    public IEnumerator TypeText(string textToType) {
        stringToPrint = textToType;
        isFinished = false;
        textObject.text = "";
        float typeProgress = 0;

        PlayTalkSound();

        while (typeProgress < stringToPrint.Length) {
            for (int i = Mathf.FloorToInt(typeProgress); i < Mathf.FloorToInt(typeProgress + Time.deltaTime * typingSpeed) && i < stringToPrint.Length; i++) 
            {
                textObject.text += stringToPrint[i];
                if (stringToPrint[i] == ' ' || stringToPrint[i] == '\n') 
                {
                    PlayTalkSound();
                }
            }
            typeProgress += Time.deltaTime * typingSpeed;
            yield return null;
        }

        isFinished = true;
    }

    public void PlayTalkSound() {
        if (baseTalkSFXPitch == 0) {
            baseTalkSFXPitch = GetComponent<AudioSource>().pitch;
        }

        GetComponent<AudioSource>().pitch = baseTalkSFXPitch + Random.Range(-1 * talkSFXPitchVariance, talkSFXPitchVariance);
        GetComponent<FadingAudioSource>().Fade(GetComponent<AudioSource>().clip, 1, false);
    }
}
