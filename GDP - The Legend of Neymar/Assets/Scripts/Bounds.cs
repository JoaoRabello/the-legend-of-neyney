using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    private BoxCollider2D bounds;
    private CameraMovement theCam;

	// Use this for initialization
	void Start () {
        
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            Debug.Log("Entrou no bound");
            bounds = GetComponent<BoxCollider2D>();
            theCam = FindObjectOfType<CameraMovement>();
            theCam.SetBounds(bounds);
        }
    }

}
