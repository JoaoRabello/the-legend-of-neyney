using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Character {

    [FMODUnity.EventRef]
    public string somChute;

    [FMODUnity.EventRef]
    public string somRetornoBola;

    [FMODUnity.EventRef]
    public string somDestranca;

    [FMODUnity.EventRef]
    public string somAlerta;

    [FMODUnity.EventRef]
    public string somImpedeDeChutar;

    private BoxCollider2D bounds;
    private CameraMovement theCam;

    public bool isAlive = true;

    public static bool bolaRecebida = false;

    public bool playerNaParede = false;
    public bool bolaDisponivel = true;
    public bool bolaOnMaxRange = false;
    public bool canChat = false;
    public bool canBeDamaged = true;
    public Vector2 bolaDir;

    //HUD
    public Image[] images;
    private int imageCount = 4;
    public Sprite semVida;

    public Image bola;
    public Sprite bolaDisable;
    public Sprite bolaEnable;
    public Image keyImg;

    public static bool canOpenDoor = false;

    
    public BallController bolaControl;
    public Rigidbody2D bolaRb;
    private Enemy enemy;
    private NPCDialogue npc;

    private EnemyBoundary enemyBounds;

    // Use this for initialization
    protected override void Start () {

        base.Start();
        bola.enabled = false;
        keyImg.enabled = false;
        life = 5;

    }
	
	// Update is called once per frame
	protected override void Update () {

        if(canMoveAgain)
        {
            GetInput();
        }

        base.Update();

	}


    private void GetInput()
    {
        //Seta direction em 0 para reiniciar a variável
        direction = Vector2.zero;

        //Verifica se a entrada do teclado indica o movimento para cima (w ou seta cima)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {

            direction += Vector2.up;
            bolaDir = new Vector2 (0, 0.7f);

        }
        else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {  //Verifica se a entrada do teclado indica o movimento para a esquerda (a ou seta esquerda)

                direction += Vector2.left; 
                bolaDir = new Vector2 (-0.5f , -0.5f);
            }
            else {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { //Verifica se a entrada do teclado indica o movimento para baixo (s ou seta baixo)

                    direction += Vector2.down;
                    bolaDir = new Vector2 (0 , -0.8f);
                }
                else {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { //Verifica se a entrada do teclado indica o movimento para a direita (d ou seta direita)

                        direction += Vector2.right;
                        bolaDir = new Vector2 (0.5f , -0.5f);
                    }
                }
            }       
        }

        if (Input.GetKeyDown(KeyCode.V) && bolaDisponivel == true && !playerNaParede && bolaRecebida)
        {
            chutaBola();
            bolaControl = FindObjectOfType<BallController>();
            bolaDisponivel = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V) && bolaDisponivel == false && bolaOnMaxRange == true && bolaRecebida)
            {
                bolaControl.canBeKicked = false;
                FMODUnity.RuntimeManager.PlayOneShot(somRetornoBola);
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.V) && bolaDisponivel == true && playerNaParede && bolaRecebida)
                {
                    FMODUnity.RuntimeManager.PlayOneShot(somImpedeDeChutar);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && canChat)
        {
            npc.canDialogue = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounds")
        {
            //Reconhece o novo bound em contato e seta os bounds da camera para o novo bound, movendo o player para solucionar um bug
            bounds = other.GetComponent<BoxCollider2D>();
            theCam = FindObjectOfType<CameraMovement>();
            theCam.SetBounds(bounds);

            if(!bolaDisponivel)
                bolaControl.bolaOutroBound = true;

            enemyBounds = other.GetComponent<EnemyBoundary>();
            if (enemyBounds.haveEnemies == true)
            {
                Instantiate(enemyBounds.enemyPool);
            }
        }

        if (other.gameObject.tag == "Enemy")
        {
            checkDeath();
            Debug.Log("Player Life: " + life);
        }

        if (other.gameObject.tag == "EnemyRange")
        {
            other.gameObject.GetComponentInParent<Enemy>().playerOnRange = true;
        }

        if (other.gameObject.tag == "Bola")
        {
            Destroy(other.gameObject);
            bolaDisponivel = true;
            bolaOnMaxRange = false;
            bola.sprite = bolaEnable;
            bolaControl.canBeKicked = true;
        }

        if (other.gameObject.tag == "NPC")
        {
            FMODUnity.RuntimeManager.PlayOneShot(somAlerta);
            canChat = true;
            npc = other.GetComponent<NPCDialogue>();
        }

        if(other.gameObject.tag == "Gaviao")
        {
            FMODUnity.RuntimeManager.PlayOneShot(somAlerta);
            canChat = true;
            npc = other.GetComponent<NPCDialogue>();
            GaviaoControl.canMove = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyRange")
        {
            other.gameObject.GetComponentInParent<Enemy>().playerOnRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyRange")
        {
            other.gameObject.GetComponentInParent<Enemy>().playerOnRange = false;
        }

        if (other.gameObject.tag == "NPC")
        {
            npc = other.GetComponent<NPCDialogue>();
            npc.canDialogue = false;
            canChat = false;
        }

        if(other.gameObject.tag == "Gaviao")
        {
            npc = other.GetComponent<NPCDialogue>();
            npc.canDialogue = false;
            canChat = false;
            GaviaoControl.canMove = true;
        }

        if(other.gameObject.tag == "Bounds")
        {

            enemyBounds = other.GetComponent<EnemyBoundary>();
            if (enemyBounds.haveEnemies == true)
            {
                Destroy(GameObject.FindGameObjectWithTag("EnemyPool"));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            playerNaParede = true;
        }
        if (col.gameObject.tag == "Door" && canOpenDoor)
        {
            FMODUnity.RuntimeManager.PlayOneShot(somDestranca);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Boss")
        {
            checkDeath();
            Debug.Log("Player Life: " + life);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            playerNaParede = false;
        }
    }
    private void chutaBola()
    {
        isAttacking = true;
        bola.sprite = bolaDisable;
        Instantiate(bolaRb, (Vector2)transform.position + bolaDir, Quaternion.identity);
        FMODUnity.RuntimeManager.PlayOneShot(somChute);
    }

    public void checkDeath()
    {
        if (life == 0)
        {
            isAlive = false;
            isDead = true;
            canMoveAgain = false;
            StartCoroutine(DestroyPlayer());
        }
    }


    public void damage()
    {
        images[imageCount].sprite = semVida;
        life--;
        imageCount--;
        StartCoroutine(DamageCoolDown());
    }

    IEnumerator DamageCoolDown()
    {
        canBeDamaged = false;
        StartCoroutine(Blinker());
        yield return new WaitForSeconds(1f);
        canBeDamaged = true;
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

    IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }

}

