using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightmareControl : MonoBehaviour {


    public static bool killNightmare = false;
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
        if (killNightmare)
            StartCoroutine(destroyThis());
    }

    void callDialogue()
    {
        dialogueTrigger.triggerDialogue();
    }
    
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(5.5f);
        
        Destroy(gameObject);
    }
}
