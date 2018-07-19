using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robertinho : MonoBehaviour {

    public Transform wp1;
    public Transform wp2;
    private Animator anim;

    private float speed = 5f;
    private bool moveTo1 = false;
    private bool moveTo2 = true;
    private bool canMove = true;
    private bool canRespira = true;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position == wp1.transform.position && canRespira)
        {
            StartCoroutine(respira(2));
        }
        else
            if (transform.position == wp2.transform.position && canRespira)
            {
                StartCoroutine(respira(1));
            }


        if (canMove)
        {
            anim.SetBool("moving", true);
            if (moveTo1)
            {
                anim.SetFloat("x", -1);
                transform.position = Vector3.MoveTowards(transform.position, wp1.transform.position, speed * Time.deltaTime);
                canRespira = true;
            }
            else
                if (moveTo2)
                {
                    anim.SetFloat("x", 1);
                    transform.position = Vector3.MoveTowards(transform.position, wp2.transform.position, speed * Time.deltaTime);
                    canRespira = true;
                }
        }
        
    }

    IEnumerator respira(int op)
    {
        canRespira = false;
        canMove = false;
        anim.SetBool("moving", false);
        yield return new WaitForSeconds(2);
        canMove = true;
        if(op == 1)
        {
            moveTo1 = true;
            moveTo2 = false;
        }
        else
        {
            moveTo1 = false;
            moveTo2 = true;
        }
    }
}
