using System.Collections;
using UnityEngine;

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
    public static bool isAttacking = false;
    public bool isDead = false;
    public bool canMoveAgain = true;
    private int i = 0;

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
            transform.Translate(direction * speed * Time.deltaTime);
        }

        //Se houver movimento (qualquer variável acima/abaixo de 0)
        if (direction.x != 0 || direction.y != 0)
        {
            AnimaMovimento(direction);
        }
        else
        {
            animator.SetBool("isMoving", false);
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

        if (Player.bolaRecebida && i == 0)
        {
            StartCoroutine(StopMoving());
            FMODUnity.RuntimeManager.PlayOneShot(pegaBola);
            animator.SetBool("isPicking", true);
            i++;
        }
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
}
