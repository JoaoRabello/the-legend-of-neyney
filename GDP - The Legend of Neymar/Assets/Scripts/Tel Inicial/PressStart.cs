using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {

    [FMODUnity.EventRef]
    public string inputSound;


    static bool canPlay;
    private LevelChanger lvlChanger;
    private FMOD_StudioEventEmitter emissor;

    private void Start()
    {
        canPlay = true;
    }

    void Update () {
        if (canPlay)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) )
            {
                canPlay = false;
                FMODUnity.RuntimeManager.PlayOneShot(inputSound);
                lvlChanger = FindObjectOfType<LevelChanger>();
                lvlChanger.fadeToLevel(1);
                Destroy(gameObject);
            }
        }
	}
    
}
