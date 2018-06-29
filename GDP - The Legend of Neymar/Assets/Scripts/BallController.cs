using UnityEngine;

public class BallController : MonoBehaviour {

    public float ballSpeed = 7f;       //Velocidade de movimento da bola
    private Player player;      //Instancia de player para receber a posição do mesmo
    private Vector2 kickDir;    //Armazena a direção do chute
    public Vector2 kickRange;  //Armazena a posição máxima do chute
    private Vector2 range;      //Armazena a distância máxima do chute (2.25)

    private Animator anim;
    public bool canBeKicked = true; 
    private Vector3 playerPos;


	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        kickDir = player.bolaDir;
        anim = GetComponent<Animator>();

        //If para evitar com que a bola vá na diagonal e setar o range do chute
        if (kickDir.x != 0)
        {
            kickDir.y = 0f;     //Evita bug de bola ir na diagonal após andar na vertical
            if (kickDir.x > 0)
                range = new Vector2(2.5f, -0.25f);
            else
                range = new Vector2(-2.55f, -0.25f);
        }
        else
        {
            if (kickDir.y > 0)
                range = new Vector2(0, 2.5f);
            else
                range = new Vector2(0, -2.5f);
        }

        //Pega a posição do player, soma o range e então armazena o alcance do chute
        kickRange = (Vector2)player.transform.position + range;   
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Leva a bola do player até a posição máxima de seu range se ainda não estiver no range máximo
        if ((Vector2)transform.position != kickRange && canBeKicked == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, kickRange, Time.deltaTime * ballSpeed);
            player.bolaOnMaxRange = false;
            anim.SetBool("isMoving", true);
        }
        else
        {
            if ((Vector2)transform.position == kickRange)
            {
                player.bolaOnMaxRange = true;
                anim.SetBool("isMoving", false);
            }
        }
        if (canBeKicked == false)
        {
            playerPos = player.transform.position + new Vector3(0,-0.25f,0);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * ballSpeed);
            anim.SetBool("isMoving", true);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            player.bolaOnMaxRange = true;
            canBeKicked = false;
            anim.SetBool("isMoving", false);
        }
    }


}
