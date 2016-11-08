using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeOutText : MonoBehaviour {

    Text textObject;
    string stringToPrint = "";

    public float typingSpeed = 0.05f;
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

        while (typeProgress < stringToPrint.Length) {
            for (int i = Mathf.FloorToInt(typeProgress); i < Mathf.FloorToInt(typeProgress + Time.deltaTime * typingSpeed) && i < stringToPrint.Length; i++) {
                textObject.text += stringToPrint[i];
            }
            typeProgress += Time.deltaTime * typingSpeed;
            yield return null;
        }

        isFinished = true;
    }
}
