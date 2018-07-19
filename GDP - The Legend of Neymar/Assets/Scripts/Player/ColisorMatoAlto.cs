using UnityEngine;

public class ColisorMatoAlto : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "MatoAlto")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "MatoAlto")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
