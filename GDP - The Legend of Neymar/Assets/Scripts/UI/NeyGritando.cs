using System.Collections;
using UnityEngine;

public class NeyGritando : MonoBehaviour
{
    private LevelChanger lvlChanger;
    NPCDialogue dial;
    int i;

    // Use this for initialization
    void Start()
    {
        dial = GetComponent<NPCDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 0)
        {
            StartCoroutine(tempos());
            i++;
        }

    }

    IEnumerator tempos()
    {
        yield return new WaitForSeconds(1);
        dial.canDialogue = true;
        yield return new WaitForSeconds(3);
        lvlChanger = FindObjectOfType<LevelChanger>();
        lvlChanger.fadeToLevel(7);
    }
}
