using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float ballSpeed = 5f;
    private Player player;
    private Vector2 kickDir;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        kickDir = player.ballDirection;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(kickDir * ballSpeed * Time.deltaTime);

	}
}
