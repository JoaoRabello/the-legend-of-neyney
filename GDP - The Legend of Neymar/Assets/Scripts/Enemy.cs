using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int life;
    private Player player;
    public float speed = 5f;
    private float enemySpeed;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        life = 5;
        enemySpeed = Time.deltaTime * speed/5f;
    }
	
	// Update is called once per frame
	void Update () {
		if (life == 0){
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bola")
        {
            life--;
            Debug.Log(life);
        }
    }

}
