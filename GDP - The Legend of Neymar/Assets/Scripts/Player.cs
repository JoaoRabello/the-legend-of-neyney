using UnityEngine;

public class Player : Character {


    private BoxCollider2D bounds;
    private CameraMovement theCam;


    public Rigidbody2D bola;
    public bool bolaDisponivel = true;
    public bool bolaOnMaxRange = false;
    public Vector2 ballDirection;
    
    public BallController ballControl;


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

            direction += Vector2.up;  // y = 1
            ballDirection = new Vector2 (0, 0.5f);

        }
        else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {  //Verifica se a entrada do teclado indica o movimento para a esquerda (a ou seta esquerda)

                direction += Vector2.left;  // x = -1
                ballDirection = new Vector2 (-0.5f , -0.25f);
            }
            else {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { //Verifica se a entrada do teclado indica o movimento para baixo (s ou seta baixo)

                    direction += Vector2.down;  // y = -1
                    ballDirection = new Vector2 (0 , -0.5f);
                }
                else {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { //Verifica se a entrada do teclado indica o movimento para a direita (d ou seta direita)

                        direction += Vector2.right;  // x = 1
                        ballDirection = new Vector2 (0.5f , -0.25f);
                    }
                }
            }       
        }

        if (Input.GetKey(KeyCode.V) && bolaDisponivel == true)
        {
            chutaBola();
            ballControl = FindObjectOfType<BallController>();
            bolaDisponivel = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.V) && bolaDisponivel == false && bolaOnMaxRange == true)
            {
                ballControl.canBeKicked = false;
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

    }

    private void chutaBola()
    {        
        Instantiate(bola, (Vector2)transform.position + ballDirection, Quaternion.identity);
    }

}

