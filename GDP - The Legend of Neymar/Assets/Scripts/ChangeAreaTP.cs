using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAreaTP : MonoBehaviour {

    public Player player;
    public Camera cam;
    public GameObject som;

    //public Vector3 firstWaypoint;
    public GameObject destinyWaypoint;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(som);
            player.transform.position = destinyWaypoint.transform.position;
            cam.transform.position = destinyWaypoint.transform.position;
        }
    }
}
