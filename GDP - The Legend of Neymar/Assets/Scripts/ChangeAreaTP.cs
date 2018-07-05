using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAreaTP : MonoBehaviour {

    public Player player;
    public Camera cam;

    //public Vector3 firstWaypoint;
    public GameObject destinyWaypoint;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            player.transform.position = destinyWaypoint.transform.position;
            cam.transform.position = destinyWaypoint.transform.position;
        }
    }
}
