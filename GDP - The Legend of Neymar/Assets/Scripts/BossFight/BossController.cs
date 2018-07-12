using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Transform[] waypoints;
    private float speed = 15f;
    private float bossSpeed;
    public int life = 5;

    private int i = 0 ;
    private int final;

    private bool outOfPatterns = false;
    private bool isAttacking = false;
    private bool canAttack = false;
    private bool tonto = false;
    private bool atAttackPoint = false;

    private bool atStartPoint = true;
    private int controlaStart = 0;
    private bool goToStart = false;

    public Transform player;
    Player playerGO;
    private Vector3 miraAtaque;
	
    // Use this for initialization
	void Start () {
         //followPattern(1);
	}

    // Update is called once per frame
    void Update() {

        bossSpeed = Time.deltaTime * speed;

        if (atStartPoint == false)
        {
            if (goToStart)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[10].transform.position, bossSpeed);
                terminouWay();
            }
            else
            {
                if (!isAttacking && !tonto)
                {
                    if (i < 11 && !outOfPatterns)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, bossSpeed);
                        terminouWay();
                    }

                    if (i == final && !atAttackPoint)
                    {
                        outOfPatterns = true;
                        transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.position, bossSpeed);
                        terminouWay();
                    }
                }
                else
                {
                    //Anda em direção ao waypoint gerado a partir do player
                    if (canAttack && !tonto)
                        transform.position = Vector3.MoveTowards(transform.position, miraAtaque, bossSpeed);
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
            i++;
        }
        if(transform.position == waypoints[0].transform.position)
        {
            Debug.Log("Vai atacar!");
            StartCoroutine(chargeAttack());
            atAttackPoint = true;
        }
        if(transform.position == waypoints[10].transform.position)
        {
            Debug.Log("Está no inicio sim");
            atStartPoint = true;
            goToStart = false;
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
            default:
                break;
        }
    }

    IEnumerator chargeAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2);
        canAttack = true;
        miraAtaque = player.position * 5;
        Debug.Log("Atacaaaaar!");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            StartCoroutine(tontura());
        }
        if(other.gameObject.tag == "Player")
        {
            playerGO = FindObjectOfType<Player>();
            playerGO.checkDeath();
            playerGO.damage();
        }
    }

    IEnumerator tontura()
    {
        tonto = true;
        canAttack = false;

        yield return new WaitForSeconds(3.5f);

        int random = Random.Range(1, 10);
        followPattern(random);

        goToStart = true;
        atAttackPoint = false;
        tonto = false;
        isAttacking = false;
        outOfPatterns = false;
    }

    IEnumerator chargePatternStart()
    {
        yield return new WaitForSeconds(1.5f);
        int random = Random.Range(1, 10);
        followPattern(random);
        atStartPoint = false;
        controlaStart = 0;
    }
}
