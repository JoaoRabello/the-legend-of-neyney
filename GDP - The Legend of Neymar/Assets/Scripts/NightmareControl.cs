using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightmareControl : MonoBehaviour {

    DialogueTrigger dialogueTrigger;
    Button button;
    DialogueManager dialManager;
    Image balaoFala;

    private bool canStart;
	
	void Start() {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        dialManager = FindObjectOfType<DialogueManager>();
        balaoFala = FindObjectOfType<Image>();
        canStart = true;
	}

    void Update()
    {
        if(canStart == true)
        {
            callDialogue();
            Time.timeScale = 0;
        }
        canStart = false;
        if (dialManager.dialogueEnded == true)
        {
            
        }
    }

    void callDialogue()
    {
        dialogueTrigger.triggerDialogue();
    }
    
}
