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

    public bool l3_tut = false;
    public bool l2 = false;
    public bool l1 = false;
    private string[] l3_tut_strings = {"Hi there! Welcome to Day 3! Today you will be fighting viruses with white blood cells!", "White Blood Cells are your body's way of fighting diseases.", "They are like a special team of virus fighting ninjas!", "Move around using the arrow keys to see if you can find an organ that has a nasty virus.", "Double click on it to send your white blood cell to go take it down!!!"};
    private string[] l2_strings = {"Welcome to Day 2!", "You are the manager of a red blood cell.", "These cells do lots of things in your body.", "But for today, your job is to do their primary function: carrying oxygen.","Move around using the arrow keys and click on your body's organs to bring oxygen to each of them!"};
    private string[] l1_strings = {"Good morning! Welcome to your first day as a Heart Beat Buddy!", "Let's start small and zoom into an arm's muscle today!", "When you work out, you create little happy cuts -- but your white blood cells need to repair them!", "Click to visit all 5 before you run out of health and heal your muscles!!"};
    
    void Start() {
        textComponent = GetComponent<TMP_Text>();
        //StartCoroutine(TextDisplay("hi there! welcome to day 3! today you will be fighting viruses with white blood cells!"));
        
    }
    private void Update() {
        if(l3_tut) {
            StartCoroutine(TextDisplay(l3_tut_strings));
            l3_tut = false;
        }
        if(l2) {
            StartCoroutine(TextDisplay(l2_strings));
            l2 = false;
        }
        if(l1) {
            StartCoroutine(TextDisplay(l1_strings));
            l1 = false;
        }
    }

    public IEnumerator TextDisplay(string[] sentences) {
        isTyping = true;
        textBox.SetActive(true);
        happyHelper.SetActive(true);
        foreach (string s in sentences)
        {
            textComponent.text = "";
            subsection = "";
            currText = s;
            foreach (char c in currText)
            {
                
                subsection += c;
                textComponent.text = subsection;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.0f);
            
        }
        
        yield return new WaitForSeconds(2.0f);
        textComponent.text = "";
        textBox.SetActive(false);
        happyHelper.SetActive(false);
        isTyping = false;
    }
}
