using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour {

    private Animator anim;
    private BoxCollider2D col;
	
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
	}
	

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Boss")
        {
            StartCoroutine(DestroyBox());
        }
    }

    IEnumerator DestroyBox()
    {
        anim.SetBool("Quebrada", true);
        col.enabled = false;
        yield return new WaitForSeconds(60);
        StartCoroutine(Blinker());
        anim.SetBool("Quebrada", false);
        col.enabled = true;
    }

    IEnumerator Blinker()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255f);

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255f);

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255f);
    }
}
