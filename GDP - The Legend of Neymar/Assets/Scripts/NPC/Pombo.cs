using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pombo : MonoBehaviour {

    private Animator anim;
    public Transform wp;
    public Transform comida;
    public bool playerPerto = false;
    public bool voa = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerPerto || voa)
        {
            anim.SetBool("parado", false);
            transform.position = Vector3.MoveTowards(transform.position, wp.transform.position, 5 * Time.deltaTime);

            if (transform.position.x > wp.transform.position.x)
                anim.SetFloat("x", -1);
            else
                    if (transform.position.x < wp.transform.position.x)
                        anim.SetFloat("x", 1);
            
            if(transform.position == wp.transform.position)
            {
                voa = false;
            }
        }
        else
        {
            if(transform.position != comida.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, comida.transform.position, 5 * Time.deltaTime);
                anim.SetBool("parado", false);

                if (transform.position.x > comida.transform.position.x)
                    anim.SetFloat("x", -1);
                else
                    if(transform.position.x < comida.transform.position.x)
                        anim.SetFloat("x", 1);
            }
            else
            {
                anim.SetBool("parado", true);
            }

        }
	}
}
