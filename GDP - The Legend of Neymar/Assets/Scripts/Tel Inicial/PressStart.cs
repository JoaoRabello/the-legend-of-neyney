using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {

    [FMODUnity.EventRef]
    public string inputSound;

    int i;

    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) && i == 0)
        {
            StartCoroutine(wait());
            i++;
        }

	}

    IEnumerator wait()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputSound);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }
}
