using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameOver : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            Application.Quit();
        }
	}
}
