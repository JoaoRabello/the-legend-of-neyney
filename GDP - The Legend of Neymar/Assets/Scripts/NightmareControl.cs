using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        dialogueTrigger.triggerDialogue(0);
    }
    
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }
}
