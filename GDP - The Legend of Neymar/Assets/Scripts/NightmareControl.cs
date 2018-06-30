using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightmareControl : MonoBehaviour {

    DialogueTrigger dialogueTrigger;
    Button button;

    private bool canStart;
	
	void Start() {
        dialogueTrigger = GetComponent<DialogueTrigger>();

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
    }

    void callDialogue()
    {
        dialogueTrigger.triggerDialogue();
    }
    
}
