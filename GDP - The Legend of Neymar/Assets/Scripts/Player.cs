
using UnityEngine;

public class Player : Character {


    private BoxCollider2D bounds;
    private CameraMovement theCam;

    private Vector3 targetPos;
    public float camSpeed;

    // Use this for initialization
    protected override void Start () {

        base.Start();

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
        }
        else {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {  //Verifica se a entrada do teclado indica o movimento para a esquerda (a ou seta esquerda)

                direction += Vector2.left;  // x = -1
            }
            else {
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { //Verifica se a entrada do teclado indica o movimento para baixo (s ou seta baixo)

                    direction += Vector2.down;  // y = -1
                }
                else {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { //Verifica se a entrada do teclado indica o movimento para a direita (d ou seta direita)

                        direction += Vector2.right;  // x = 1
                    }
                }
            }       
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounds")
        {
            Debug.Log("Entrou no bound");

            bounds = other.GetComponent<BoxCollider2D>();
            theCam = FindObjectOfType<CameraMovement>();
            //theCam.transform.Translate(transform.position.x + 10, transform.position.y + 10, 0);
            //float step = camSpeed * Time.deltaTime;
            //targetPos = new Vector3(transform.position.x + 50, 0, 0);
            //theCam.transform.position = Vector3.MoveTowards(theCam.transform.position, targetPos, step);
            theCam.SetBounds(bounds);
        }
    }

}
