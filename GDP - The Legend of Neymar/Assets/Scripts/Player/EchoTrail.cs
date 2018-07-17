using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoTrail : MonoBehaviour {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echoUp;
    public GameObject echoDown;
    public GameObject echoRight;
    public GameObject echoLeft;
    public Player player;
	
	// Update is called once per frame
	void Update () {
        if(player.isDashing == true)
            if (timeBtwSpawns <= 0)
            {
                if (player.direction.y >= 1)
                {
                    GameObject instance = Instantiate(echoUp, transform.position, Quaternion.identity);
                    Destroy(instance, 0.8f);
                }
                else
                {
                    if (player.direction.y <= -1)
                    {
                        GameObject instance = Instantiate(echoDown, transform.position, Quaternion.identity);
                        Destroy(instance, 0.8f);
                    }
                    else
                    {
                        if(player.direction.x <= -1)
                        {
                            GameObject instance = Instantiate(echoLeft, transform.position, Quaternion.identity);
                            Destroy(instance, 0.8f);
                        }
                        else
                        {
                            if(player.direction.x >= 1)
                            {
                                GameObject instance = Instantiate(echoRight, transform.position, Quaternion.identity);
                                Destroy(instance, 0.8f);
                            }
                        }
                    }
                }
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
	}
}
