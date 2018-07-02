using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    private Player player;
    private Animator anim;

    //Atributos de batalha e movimento
    public int life;
    public float speed = 6f;
    private float enemySpeed;
    public static bool playerOnRange;
    private bool isDead;
    public bool canPursuit = true;

    //Atributo de movimento (posição anterior)
    private Vector3 lastPos;


    void Start() {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        life = 5;

    }

    // Update is called once per frame
    void Update() {
        lastPos = transform.position;

        enemySpeed = Time.deltaTime * speed / 5f;

        if (player.isAlive && playerOnRange == true && isDead == false && canPursuit == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);

            anim.SetBool("moving", true);
            
            //Se a posição anterior for maior que a atual, indica movimento para a esquerda
            if (lastPos.x >= transform.position.x)
            {
                anim.SetFloat("X", -1f);
            }
            else
            {
                anim.SetFloat("X", 1f);
            }
        }
        else
        {
            if(player.isAlive == false || playerOnRange == false || canPursuit == false)
            {
                anim.SetBool("moving", false);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPursuit = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPursuit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bola")
        {
            life--;
            checkDeath();
            Debug.Log("Enemy Life: " + life);
        }
    }

    private void checkDeath()
    {
        if (life == 0)
        {
            isDead = true;
            anim.SetBool("isDead", true);
            StartCoroutine(Destroytimer());
        }
    }

    IEnumerator Destroytimer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
