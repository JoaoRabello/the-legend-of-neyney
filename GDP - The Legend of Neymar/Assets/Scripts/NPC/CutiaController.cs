using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutiaController : MonoBehaviour
{

    private Vector2 thisPos;
    private Vector2 nextPos;
    private int randomX;
    private int randomY;
    private int randomDirection;
    private float speed = 3f;
    public bool canMove = true;

    public bool playerOnRange = false;
    public bool runToToca = false;

    private float timeToChangeDirection;

    private Animator anim;
    public Player player;
    private BoxCollider2D col;
    public Transform toca;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        changeDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisPos = transform.position;
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            changeDirection();
        }

        if (canMove && playerOnRange == false && runToToca == false)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            if (runToToca || playerOnRange)
            {
                changeDirection();
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
                if(runToToca)
                    col.enabled = false;
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
        if (transform.position == toca.transform.position)
        {
            runToToca = false;
            col.enabled = true;
            anim.SetBool("isMoving", false);
        }
    }

    public void changeDirection()
    {
        if (playerOnRange || runToToca)
        {
            speed = 10;
            nextPos = toca.transform.position;
            runToToca = true;
        }
        else
        {
            speed = 3;
            randomDirection = Random.Range(1, 101);
            if (randomDirection <= 50)
            {
                randomX = Random.Range(-10, 10);
                if (randomX > 0)
                {
                    anim.SetFloat("X", 1);
                }
                else
                {
                    anim.SetFloat("X", -1);
                }
                nextPos = thisPos + new Vector2(randomX, 0);
            }
            else
            {
                if (randomDirection > 50)
                {
                    randomY = Random.Range(-10, 10);
                    nextPos = thisPos + new Vector2(0, randomY);
                }
            }
        }
        timeToChangeDirection = 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            anim.SetBool("isMoving", false);
            changeDirection();
        }
    }
}