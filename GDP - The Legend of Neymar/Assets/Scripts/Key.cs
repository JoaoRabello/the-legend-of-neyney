using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {
    public Image keyImg;

    private void Start()
    {
        keyImg.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            keyImg.enabled = true;
            Player.canOpenDoor = true;
            Destroy(gameObject);
        }
    }
}
