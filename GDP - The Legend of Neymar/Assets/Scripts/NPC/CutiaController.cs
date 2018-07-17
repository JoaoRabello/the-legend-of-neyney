using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutiaController : MonoBehaviour
{

    public static bool canGiveBall = false;
    public static int canGiveBallCont = 0;
    private int i = 0;

    private Vector2 thisPos;
    private Vector2 nextPos;
    private int randomX;
    private int randomY;
    private int randomDirection;
    private float speed = 0.5f;
    public static bool canMove = true;

    private float timeToChangeDirection;

    private Animator anim;
    public Player player;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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

        if (canMove)
        {
            anim.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    void changeDirection()
    {
        randomDirection = Random.Range(1, 101);
        if (randomDirection <= 50)
        {
            randomX = Random.Range(-10, 10);
            anim.SetFloat("y", 0);
            if (randomX > 0)
            {
                anim.SetFloat("x", 1);
            }
            else
            {
                anim.SetFloat("x", -1);
            }
            nextPos = thisPos + new Vector2(randomX, 0);
        }
        else
        {
            if (randomDirection > 50)
            {
                randomY = Random.Range(-10, 10);
                anim.SetFloat("x", 0);
                if (randomY > 0)
                {
                    anim.SetFloat("y", 1);
                }
                else
                {
                    anim.SetFloat("y", -1);
                }
                nextPos = thisPos + new Vector2(0, randomY);
            }
        }
        timeToChangeDirection = 2f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            changeDirection();
        }
    }
}