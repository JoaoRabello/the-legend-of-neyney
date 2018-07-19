using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FulecoCutscene : MonoBehaviour {

    private Animator anim;
    private LevelChanger lvlChanger;

    public static int podeMudarCena = 0;

    public bool canTalk;
    private int i;

	// Use this for initialization
	void Start () {
        i = 0;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canTalk)
        {
            if (i == 0)
            {
                GetComponent<NPCDialogue>().canDialogue = true;
                i++;
            }

            if (GetComponent<NPCDialogue>().dialogueCounter == 1 && i == 1)
            {
                StartCoroutine(rasgarCamisa());
                i++;
            }
            
            if(podeMudarCena == 3)
            {
                lvlChanger = FindObjectOfType<LevelChanger>();
                lvlChanger.fadeToLevel(4);
            }

        }
	}

    IEnumerator rasgarCamisa()
    {
        GetComponent<NPCDialogue>().canDialogue = false;
        anim.SetBool("rasga", true);
        yield return new WaitForSeconds(1.1f);
        GetComponent<NPCDialogue>().canDialogue = true;
    }
}
