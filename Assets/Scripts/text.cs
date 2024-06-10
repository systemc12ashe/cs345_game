using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    
    public TMP_Text textComponent;
    private string currText = "Great Work! You've made it to day 3!";
    private string subsection = "";

    static bool isTyping = false;
    public GameObject happyHelper;
    public GameObject textBox;

    static bool l3_tut = false;

    void Start() {
        textComponent = GetComponent<TMP_Text>();
        //StartCoroutine(TextDisplay("hi there! welcome to day 3! today you will be fighting viruses with white blood cells!"));
        l3_tut = true;
    }
    private void Update() {
        if(l3_tut) {
            StartCoroutine(TextDisplay("hi there! welcome to day 3! today you will be fighting viruses with white blood cells!"));
            l3_tut = false;
        }
    }

    public IEnumerator TextDisplay(string sentence) {
        currText = sentence;
        isTyping = true;
        textBox.SetActive(true);
        happyHelper.SetActive(true);
        foreach (char c in currText)
        {
            subsection += c;
            textComponent.text = subsection;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.0f);
        textComponent.text = "";
        textBox.SetActive(false);
        happyHelper.SetActive(false);
        isTyping = false;
    }
}
