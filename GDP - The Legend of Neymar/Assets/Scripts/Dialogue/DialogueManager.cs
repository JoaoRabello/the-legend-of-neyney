﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public TMP_Text dialogueText;

    private Queue<string> argumentos;

    public bool dialogueEnded;

	// Use this for initialization
	void Start () {
        argumentos = new Queue<string>();
	}

    public void startDialogue (Dialogue dialogue)
    {
        dialogueEnded = false;
        argumentos.Clear();
        
        foreach(string argumento in dialogue.argumentos)
        {
            argumentos.Enqueue(argumento);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if (argumentos.Count == 0)
        {
            endDialogue();
            return;
        }

        string argumento = argumentos.Dequeue();

        StopAllCoroutines();
        StartCoroutine(typeSequence(argumento));
    }

    IEnumerator typeSequence(string argumento)
    {
        dialogueText.text = "";
        foreach(char letra in argumento.ToCharArray())
        {
            dialogueText.text += letra;
            yield return null;
        }
    }

    public void endDialogue()
    {
        Debug.Log("End of Dialogue");
        Time.timeScale = 1;
        dialogueEnded = true;
    }
}