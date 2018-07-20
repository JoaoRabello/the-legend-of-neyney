using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [FMODUnity.EventRef]
    public string somQuica;

    [FMODUnity.EventRef]
    public string somQuebraCaixa;

    [FMODUnity.EventRef]
    public string somTontura;

    [FMODUnity.EventRef]
    public string somVoltaInicio;

    public Transform[] waypoints;
    private float speed = 15f;
    private float bossSpeed;
    public int life;

    private int i = 0;
    private int damageCount = 0;
    private int final;

    private bool outOfPatterns = false;
    private bool isAttacking = false;
    private bool canAttack = false;
    private bool tonto = false;
    private bool atAttackPoint = false;

    private bool atStartPoint = true;
    private int controlaStart = 0;
    private bool goToStart = false;

    private bool canBeDamaged = false;

    public Transform player;
    Player playerGO;
    private Vector3 miraAtaque;
    private Animator anim;
    public BoxCollider2D neyney;
    public CapsuleCollider2D buraco;

    private bool canStartRollAnim = true;
	
    // Use this for initialization
	void Start () {
        life = 5;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        bossSpeed = Time.deltaTime * speed;

        if (atStartPoint == false)
        {
            if (goToStart)
            {
                if(canStartRollAnim)
                    StartCoroutine(startRoll());

                transform.position = Vector3.MoveTowards(transform.position, waypoints[30].transform.position, bossSpeed);
                animaRoll(waypoints[30].transform.position);
                terminouWay();
            }
            else
            {
                if (!isAttacking && !tonto)
                {
                    if (i < 31 && !outOfPatterns)
                    {
                        if(canStartRollAnim)
                            StartCoroutine(startRoll());

                        transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, bossSpeed);
                        animaRoll(waypoints[i].transform.position);
                        terminouWay();
                    }

                    if (i == final && !atAttackPoint)
                    {
                        outOfPatterns = true;
                        transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.position, bossSpeed);
                        animaRoll(waypoints[0].transform.position);
                        terminouWay();
                    }
                }
                else
                {
                    //Anda em direção ao waypoint gerado a partir do player (ataca o player)
                    if (canAttack && !tonto)
                    {
                        if(canStartRollAnim)
                            StartCoroutine(startRoll());

                        transform.position = Vector3.MoveTowards(transform.position, miraAtaque, bossSpeed);
                        animaRoll(miraAtaque);
                    }
                        
                }
            }
        }
        else
        {
            if(atStartPoint == true && controlaStart == 0)
            {
                StartCoroutine(chargePatternStart());
                controlaStart++;
            }

        }
        
    }

    private void terminouWay()
    {

        if (transform.position == waypoints[i].transform.position)
        {
            if(final != 30)
                FMODUnity.RuntimeManager.PlayOneShot(somQuica);
            i++;
        }

        //Se  estiver no ponto de ataque (colchao), faça
        if(transform.position == waypoints[0].transform.position)
        {
            Debug.Log("Vai atacar!");
            canStartRollAnim = true;
            StartCoroutine(chargeAttack());
            atAttackPoint = true;
        }

        //Se estiver no ponto de inicio, faça
        if(transform.position == waypoints[30].transform.position)
        {
            Debug.Log("Está no inicio sim");
            atStartPoint = true;
            goToStart = false;
            canStartRollAnim = true;
            StartCoroutine(chargePatternStart());
        }
    }

    private void followPattern(int o)
    {
        switch (o)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                i = 1;
                final = 6;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                i = 6;
                final = 10;
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                i = 10;
                final = 30;
                break;
            default:
                break;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            FMODUnity.RuntimeManager.PlayOneShot(somQuebraCaixa);
            StartCoroutine(tontura());
            anim.SetBool("isTonto", true);
        }

        if(other.gameObject.tag == "Wall")
        {
            atStartPoint = false;
            goToStart = true;
            canAttack = false;
            isAttacking = false;
            atAttackPoint = false;

            outOfPatterns = false;

            FMODUnity.RuntimeManager.PlayOneShot(somVoltaInicio);
            //StartCoroutine(tontura());
            //anim.SetBool("isTonto", true);
        }

        if (other.gameObject.tag == "Player")
        {
            playerGO = FindObjectOfType<Player>();
            if (playerGO.canBeDamaged)
            {
                playerGO.damage();
                playerGO.checkDeath();
            }
        }

        if (other.gameObject.tag == "Bola" && canBeDamaged)
        {
            if(damageCount == 0)
            {
                life--;
                checkDeath();
                damageCount++;
            }

        }
    }

    void checkDeath()
    {
        if(life == 0)
        {
            StartCoroutine(death());
        }
    }

    void animaRoll(Vector3 move)
    {
        if(transform.position.x > move.x)
        {
            anim.SetFloat("X", 1);
        }
        else
        {
            if(transform.position.x < move.x)
            {
                anim.SetFloat("X", -1);
            }
        }
        anim.SetFloat("Y", move.y);
    }

    IEnumerator death()
    {
        anim.SetBool("morto", true);
        yield return new WaitForSeconds(0.8f);
        neyney.enabled = true;
        buraco.enabled = true;
        Destroy(gameObject);
    }

    IEnumerator startRoll()
    {
        anim.SetBool("isStartingRoll", true);
        speed = 7;
        yield return new WaitForSeconds(0.2f);
        speed = 15;
        anim.SetBool("isStartingRoll", false);
        canStartRollAnim = false;
    }

    IEnumerator chargeAttack()
    {
        isAttacking = true;
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("isIdle", false);
        canAttack = true;
        miraAtaque = player.position * 20;
        Debug.Log("Atacaaaaar!");
    }

    IEnumerator tontura()
    {
        tonto = true;
        canAttack = false;
        canBeDamaged = true;
        yield return new WaitForSeconds(1.25f);
        FMODUnity.RuntimeManager.PlayOneShot(somTontura);
        yield return new WaitForSeconds(1.25f);
        FMODUnity.RuntimeManager.PlayOneShot(somTontura);
        yield return new WaitForSeconds(1.25f);
        FMODUnity.RuntimeManager.PlayOneShot(somTontura);
        yield return new WaitForSeconds(1.25f);

        corrigeParaInicio();
    }

    IEnumerator chargePatternStart()
    {
        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isIdle", false);
        int random = Random.Range(1, 15);
        followPattern(random);
        atStartPoint = false;
        controlaStart = 0;
    }

    void corrigeParaInicio()
    {
        int random = Random.Range(1, 15);
        followPattern(random);

        goToStart = true;
        atAttackPoint = false;
        tonto = false;
        isAttacking = false;
        outOfPatterns = false;

        canBeDamaged = false;
        damageCount = 0;

        anim.SetBool("isTonto", false);
    }
}
