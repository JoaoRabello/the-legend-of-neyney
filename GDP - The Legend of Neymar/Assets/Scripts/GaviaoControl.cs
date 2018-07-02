using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaviaoControl : MonoBehaviour {

    public static bool canGiveBall = false;
    public static int canGiveBallCont = 0;

    private Vector2 thisPos;
    private Vector2 nextPos;
    private int randomX;
    private int randomY;
    private int randomDirection;
    private float speed = 20f;
    private bool canMove = true;
    private bool canMoveCollide = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        thisPos = transform.position;

        randomDirection = Random.Range(1, 101);

        if (randomDirection <= 50)
        {
            Debug.Log("Move em x");
            randomX = Random.Range(-2, 2);
            nextPos = thisPos + new Vector2(randomX, 0);
        }
        else
        {
            if (randomDirection > 50)
            {
                Debug.Log("Move em y");
                randomY = Random.Range(-2, 2);
                nextPos = thisPos + new Vector2(0, randomY);
            }
        } 

        if (canMove && canMoveCollide)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            StartCoroutine(stop());
        }
        

        if (canGiveBall == true)
        {
            //Roda animação entregando a bola
            Debug.Log("Recebeu bola");
            Player.bolaRecebida = true;
            canGiveBall = false;
        }
	}

    IEnumerator stop()
    {
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
