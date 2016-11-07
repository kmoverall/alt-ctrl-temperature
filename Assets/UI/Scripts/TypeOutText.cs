using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeOutText : MonoBehaviour {

    Text textObject;
    string stringToPrint = "";

    public float typingSpeed = 100;
    [HideInInspector]
    public bool isFinished = false;

    void OnEnable() {
        PrepText();
        stringToPrint = "TESTTESTTESTTESTTESTTEST\nTESTTESTTESTTESTTESTTESTTESTTESTTEST\nTESTESTESTESTESTEST";
        StartTyping(stringToPrint);
    }

    public void PrepText() {
        textObject = GetComponent<Text>();
        textObject.text = "";
    }

    // Update is called once per frame
    public void StartTyping(string textToType) {
        stringToPrint = textToType;
        StartCoroutine(TypeText());
    }

    public void Interrupt() {
        StopCoroutine("TypeText");
        textObject.text = stringToPrint;
        isFinished = true;
    }

    IEnumerator TypeText() {
        isFinished = false;
        textObject.text = "";
        float typeProgress = 0;

        while (typeProgress < stringToPrint.Length) {
            for (int i = Mathf.FloorToInt(typeProgress); i < Mathf.FloorToInt(typeProgress + Time.deltaTime * typingSpeed); i++) {
                textObject.text += stringToPrint[i];
            }
            typeProgress += Time.deltaTime * typingSpeed;
            yield return null;
        }

        isFinished = true;
    }
}
