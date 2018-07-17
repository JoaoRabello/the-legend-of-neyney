using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour {

    DialogueTrigger dialogueTrigger;

    public bool canDialogue = false;

    void Start () {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Update(){
        if (canDialogue)
        {
            dialogueTrigger.triggerDialogue();
            Time.timeScale = 0;
        }
        canDialogue = false;
    }
}
