using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour {

    DialogueTrigger dialogueTrigger;

    public bool canDialogue = false;
    public int numOfDialogues;
    public int dialogueCounter = 0;

    void Start () {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void Update(){
        if(dialogueCounter < numOfDialogues)
        {
            switch (dialogueCounter)
            {
                case 0:
                    if (canDialogue)
                    {
                        dialogueTrigger.triggerDialogue(0);
                        Time.timeScale = 0;
                        if(dialogueCounter < numOfDialogues - 1)
                            dialogueCounter++;
                    }
                    break;
                case 1:
                    if (canDialogue)
                    {
                        dialogueTrigger.triggerDialogue(1);
                        Time.timeScale = 0;
                        if (dialogueCounter < numOfDialogues - 1)
                            dialogueCounter++;
                    }
                    break;
                case 2:
                    if (canDialogue)
                    {
                        dialogueTrigger.triggerDialogue(2);
                        Time.timeScale = 0;
                        if (dialogueCounter < numOfDialogues - 1)
                            dialogueCounter++;
                    }
                    break;
                case 3:
                    if (canDialogue)
                    {
                        dialogueTrigger.triggerDialogue(3);
                        Time.timeScale = 0;
                        if (dialogueCounter < numOfDialogues - 1)
                            dialogueCounter++;
                    }
                    break;
                case 4:
                    if (canDialogue)
                    {
                        dialogueTrigger.triggerDialogue(4);
                        Time.timeScale = 0;
                        if (dialogueCounter < numOfDialogues - 1)
                            dialogueCounter++;
                    }
                    break;
                default:
                    break;
            }
            
        }
        
        canDialogue = false;
    }
}
