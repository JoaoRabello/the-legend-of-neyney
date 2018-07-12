using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDamage : MonoBehaviour {


    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Blinker());
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Blinker()
    {

        for(int i = 0; i < 3; i++)
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

            yield return new WaitForSeconds(0.2f);

            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);

            yield return new WaitForSeconds(0.2f);

            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 255f);
        }


    }
}
