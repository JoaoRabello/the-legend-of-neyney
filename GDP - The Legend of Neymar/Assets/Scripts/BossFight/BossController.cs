using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public Transform[] waypoints;
    private float speed = 15f;
    private float bossSpeed;

    private int i = 0 ;
    private int final;

    private bool outOfPatterns = false;
    private bool isAttacking = false;
    private bool canAttack = false;
    private bool tonto = false;
    private bool atAttackPoint = false;

    public Transform player;
    private Vector3 miraAtaque;
	
    // Use this for initialization
	void Start () {
         followPattern(1);
	}

    // Update is called once per frame
    void Update() {

        bossSpeed = Time.deltaTime * speed;


        if (!isAttacking && !tonto)
        {
            if (i < 11 && !outOfPatterns)
            {
                Debug.Log("Indo para os waypoints");
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
            if(canAttack && !tonto)
                transform.position = Vector3.MoveTowards(transform.position, miraAtaque, bossSpeed);
        }
    }

    private void terminouWay()
    {
        Debug.Log(i);
        if (transform.position == waypoints[i].transform.position)
        {
            //if(i<final)
                i++;
        }
        if(transform.position == waypoints[0].transform.position)
        {
            Debug.Log("Vai atacar!");
            StartCoroutine(chargeAttack());
            atAttackPoint = true;
        }
    }

    private void followPattern(int o)
    {
        switch (o)
        {
            case 1:
                i = 1;
                final = 5;
                break;
            case 2:
                i = 6;
                final = 9;
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
        miraAtaque = player.position * 2;
        Debug.Log(miraAtaque);
        Debug.Log("Atacaaaaar!");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            StartCoroutine(tontura());
        }
    }

    IEnumerator tontura()
    {
        tonto = true;
        canAttack = false;
        yield return new WaitForSeconds(3.5f);
        followPattern(2);
        atAttackPoint = false;
        tonto = false;
        isAttacking = false;
        outOfPatterns = false;
    }
}
