using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    [FMODUnity.EventRef]
    public string somPegarAChave;

    [FMODUnity.EventRef]
    public string somChaveSurge;

    public Image keyImg;
    private SpriteRenderer key;
    private BoxCollider2D keyCollider;
    public Player player;
    private Animator playeranim;

    public int enemiesToKill;
    private int i = 0;

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
        if(player.enemyKilled == enemiesToKill && i == 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(somChaveSurge);
            key.enabled = true;
            keyCollider.enabled = true;
            i++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FMODUnity.RuntimeManager.PlayOneShot(somPegarAChave);
            keyImg.enabled = true;
            Player.canOpenDoor = true;
            Destroy(gameObject);
        }
    }
}
