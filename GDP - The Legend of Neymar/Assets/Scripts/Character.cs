
using UnityEngine;

public class Character : MonoBehaviour {

    //Serialize field aqui torna a variável private speed visivel no Inspector
    [SerializeField]
    protected float speed;

    //Variável para contar a vida
    protected int life;

    //Armazena a direção
    public Vector2 direction;

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
        transform.Translate(direction * speed * Time.deltaTime);

        //Se houver movimento (qualquer variável acima/abaixo de 0)
        if (direction.x != 0 || direction.y != 0)
            //Gera as transições de movimento
            AnimaMovimento(direction);
        else
            //Senão, mantém a Layer Idle em foco, passando o weight de Walk para 0
            animator.SetLayerWeight(1, 0);
    }

    public void AnimaMovimento(Vector2 drct) {


        //Layer Walk ganha o foco
        animator.SetLayerWeight(1, 1);

        //Inica ao animator em que sentido o player parou (se parou andando para a esquerda, x = -1)
        animator.SetFloat("x", drct.x);
        animator.SetFloat("y", drct.y);

    }
}
