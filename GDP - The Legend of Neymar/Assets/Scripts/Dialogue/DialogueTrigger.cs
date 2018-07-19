using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;

    public void triggerDialogue(int op)
    {
        switch (op)
        {
            case 0:
                FindObjectOfType<DialogueManager>().startDialogue(dialogue);
                break;
            case 1:
                FindObjectOfType<DialogueManager>().startDialogue(dialogue1);
                break;
            case 2:
                FindObjectOfType<DialogueManager>().startDialogue(dialogue2);
                break;
            case 3:
                FindObjectOfType<DialogueManager>().startDialogue(dialogue3);
                break;
            case 4:
                FindObjectOfType<DialogueManager>().startDialogue(dialogue4);
                break;
            default:
                break;
        }

    }
}