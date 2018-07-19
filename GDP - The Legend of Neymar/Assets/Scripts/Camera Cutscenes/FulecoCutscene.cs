using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FulecoCutscene : MonoBehaviour {

    public bool canTalk;
    private int i;

	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (canTalk)
        {
            Debug.Log("Fuleco pode falar!");
            if (i == 0)
            {
                Debug.Log("Fuleco fala");
                GetComponent<NPCDialogue>().canDialogue = true;
                i++;
            }
        }
	}
}
