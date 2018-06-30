using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {
	
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.KeypadEnter))
            SceneManager.LoadScene(1);

	}
}
