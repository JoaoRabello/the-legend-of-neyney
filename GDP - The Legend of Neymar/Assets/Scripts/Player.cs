using UnityEngine;

public class Player : Character {


    private BoxCollider2D bounds;
    private CameraMovement theCam;

    public bool isAlive = true;

    public bool playerNaParede = false;
    public bool bolaDisponivel = true;
    public bool bolaOnMaxRange = false;
    public Vector2 bolaDir;
    
    public BallController bolaControl;
    public Rigidbody2D bolaRb;
    private Enemy enemy;

    // Use this for initialization
    protected override void Start () {

        base.Start();

        life = 5;

    }
	
	// Update is called once per frame
	protected override void Update () {

        GetInput();

        base.Update();


	}


    private void GetInput()
    {
        //Seta direction em 0 para reiniciar a variável
        direction = Vector2.zero;

        //Verifica se a entrada do teclado indica o movimento para cima (w ou seta cima)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {

            direction += Vector2.up;
            bolaDir = new Vector2 (0, 0.5f);

        }
        else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {  //Verifica se a entrada do teclado indica o movimento para a esquerda (a ou seta esquerda)

                direction += Vector2.left; 
                bolaDir = new Vector2 (-0.5f , -0.25f);
            }
            else {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { //Verifica se a entrada do teclado indica o movimento para baixo (s ou seta baixo)

                    direction += Vector2.down;
                    bolaDir = new Vector2 (0 , -0.8f);
                }
                else {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { //Verifica se a entrada do teclado indica o movimento para a direita (d ou seta direita)

                        direction += Vector2.right;
                        bolaDir = new Vector2 (0.5f , -0.25f);
                    }
                }
            }       
        }

        if (Input.GetKeyDown(KeyCode.V) && bolaDisponivel == true && !playerNaParede)
        {
            chutaBola();
            bolaControl = FindObjectOfType<BallController>();
            bolaDisponivel = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V) && bolaDisponivel == false && bolaOnMaxRange == true)
            {
                bolaControl.canBeKicked = false;
            }
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
            float tempSpeed = 25f;
            transform.Translate(direction * tempSpeed * Time.deltaTime);
        }

        if (other.gameObject.tag == "Enemy")
        {
            life--;
            checkDeath();
            Debug.Log("Player Life: " + life);
        }

        if (other.gameObject.tag == "EnemyRange")
        {
            Enemy.playerOnRange = true;
        }

        if (other.gameObject.tag == "Bola")
        {
            Destroy(other.gameObject);
            bolaDisponivel = true;
            bolaOnMaxRange = false;
            bolaControl.canBeKicked = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyRange")
        {
            Enemy.playerOnRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyRange")
        {
            Enemy.playerOnRange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            playerNaParede = true;
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
        Instantiate(bolaRb, (Vector2)transform.position + bolaDir, Quaternion.identity);
    }

    private void checkDeath()
    {
        if (life == 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
}

