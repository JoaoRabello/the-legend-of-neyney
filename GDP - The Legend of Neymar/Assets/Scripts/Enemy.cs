using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [FMODUnity.EventRef]
    public string somMorte;

    [FMODUnity.EventRef]
    public string somDano;


    private Player player;
    private Animator anim;
    private GameObject bola;

    //Atributos de batalha e movimento
    public int life = 0;
    public float speed = 6f;
    private float enemySpeed;
    public bool playerOnRange;
    private bool isDead;

    public bool canPursuit = true;
    public bool canBeDamaged = true;

    private bool canGiveDMG = true;

    //Atributo de movimento (posição anterior)
    private Vector3 lastPos;


    void Start() {
       
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
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
            if(canGiveDMG && player.canBeDamaged)
            {
                player.damage();
                player.checkDeath();
            }
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
            FMODUnity.RuntimeManager.PlayOneShot(somDano);
            bola = other.gameObject;
            StartCoroutine(Blinker());
            checkDeath();
            Debug.Log("Enemy Life: " + life);
        }
    }

    private void checkDeath()
    {
        if (life == 0)
        {
            isDead = true;
            FMODUnity.RuntimeManager.PlayOneShot(somMorte);
            canGiveDMG = false;
            anim.SetBool("isDead", true);
            StartCoroutine(Destroytimer());
        }
    }

    IEnumerator Blinker()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0, 0);

        canPursuit = false;
        canBeDamaged = false;

        yield return new WaitForSeconds(0.2f);

        canBeDamaged = true;
        canPursuit = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255f);
    }

    IEnumerator Destroytimer()
    {
        
        yield return new WaitForSeconds(1);
        player.enemyKilled++;
        Destroy(gameObject);
    }
}
