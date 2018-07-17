using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public Image keyImg;
    private SpriteRenderer key;
    private BoxCollider2D keyCollider;
    public Player player;

    public int enemiesToKill;

    private void Start()
    {
        keyImg.enabled = false;
        key = GetComponent<SpriteRenderer>();
        keyCollider = GetComponent<BoxCollider2D>();
        key.enabled = false;
        keyCollider.enabled = false;
    }

    private void Update()
    {
        if(player.enemyKilled == enemiesToKill)
        {
            key.enabled = true;
            keyCollider.enabled = true;
        }
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
