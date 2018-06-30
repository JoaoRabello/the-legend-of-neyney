using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour {

    DialogueTrigger dialogueTrigger;
    
    void Start () {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }


    void Update(){

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Está em contato, pode conversar");
        }
    }

}
