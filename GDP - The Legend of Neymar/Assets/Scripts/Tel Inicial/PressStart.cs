using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {

    [FMODUnity.EventRef]
    public string inputSound;

    static bool canPlay = true;

    void Update () {
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) )
            {
                Debug.Log("Começa jogo");
                canPlay = false;
                FMODUnity.RuntimeManager.PlayOneShot(inputSound);
                StartCoroutine(wait());
            }
        }
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }
}
