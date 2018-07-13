using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {

    //Serialize field aqui torna a variável private speed visivel no Inspector
    [SerializeField]
    protected float speed;

    [FMODUnity.EventRef]
    public string pegaBola;

    //Variável para contar a vida
    protected int life;
    

    //Armazena a direção
    public Vector2 direction;
    public Vector2 dashDirection;
    public static bool isAttacking = false;
    public bool isDead = false;
    public bool canMoveAgain = true;
    private int i = 0;
    protected bool isDashing = false;
    protected bool canDash = true;
    protected bool canDashInput = true;
    protected int dashInput;

    private Animator animator;


    // Use this for initialization
    protected virtual void Start () {

        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	protected virtual void Update () {

        Move();

    }

    //Método para mover o personagem que possui este script
    void Move() {

        // Calcula direções para ser usado no métoo Translate (move o objeto)
        if (canMoveAgain)
        {
            if(isDashing == false)
            {
                transform.Translate(direction * speed * Time.deltaTime);
            
                //Se houver movimento (qualquer variável acima/abaixo de 0)
                if (direction.x != 0 || direction.y != 0)
                {
                    AnimaMovimento(direction);
                }
                else
                {
                    animator.SetBool("isMoving", false);
                }
            }
            else
            {
                if (isDashing == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, dashDirection, speed * 4 * Time.deltaTime);
                    canDashInput = false;
                }
            }
            
        }



        
        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (isDead)
        {
            animator.SetBool("isDead", true);
        }

        if (Player.bolaRecebida && i == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(StopMoving());
            FMODUnity.RuntimeManager.PlayOneShot(pegaBola);
            animator.SetBool("isPicking", true);
            i++;
        }
    }

    protected void Dash()
    {
        if(canDash == true)
            StartCoroutine(Dashing());
    }

    public void AnimaMovimento(Vector2 drct) {

        animator.SetBool("isMoving", true);

        //Inica ao animator em que sentido o player parou (se parou andando para a esquerda, x = -1)
        animator.SetFloat("x", drct.x);
        animator.SetFloat("y", drct.y);

    }

    IEnumerator StopMoving()
    {
        canMoveAgain = false;
        yield return new WaitForSeconds(3);
        canMoveAgain = true;
        animator.SetBool("isPicking", false);
    }

    IEnumerator Dashing()
    {
        isDashing = true;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        canDash = false;
        StartCoroutine(DashCooldown());
        canDashInput = true;
        dashInput = 0;
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canDash = true;
    }
}
