using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outro : MonoBehaviour {

    private LevelChanger lvlChanger;
    NPCDialogue dial;
    int i;
    public static bool gotocredits = false;
    // Use this for initialization
    void Start()
    {
        dial = GetComponent<NPCDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            StartCoroutine(tempos());
            i++;
        }

        if (gotocredits)
        {
            lvlChanger = FindObjectOfType<LevelChanger>();
            lvlChanger.fadeToLevel(8);
        }

    }
    
    IEnumerator tempos()
    {
        yield return new WaitForSeconds(1.2f);
        dial.canDialogue = true;
    }
}
