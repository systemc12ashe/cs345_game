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

    void Start() {
        textComponent = GetComponent<TMP_Text>();
        StartCoroutine(TextDisplay("hi there! welcome to day 3! today you will be fighting viruses with white blood cells!"));
    }
    private void Update() {
        
    }

    public IEnumerator TextDisplay(string sentence) {
        currText = sentence;
        isTyping = true;
        foreach (char c in currText)
        {
            subsection += c;
            textComponent.text = subsection;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
    }
}
