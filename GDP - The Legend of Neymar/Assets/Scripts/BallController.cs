using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    float ballSpeed = 5f;       //Velocidade de movimento da bola
    private Player player;      //Instancia de player para receber a posição do mesmo
    private Vector2 kickDir;    //Armazena a direção do chute
    private Vector2 kickRange;  //Armazena a posição máxima do chute
    private Vector2 range;      //Armazena a distância máxima do chute (2.25)

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        kickDir = player.ballDirection;

        //If para evitar com que a bola vá na diagonal e setar o range do chute
        if (kickDir.x != 0)
        {
            kickDir.y = 0f;     //Evita bug de bola ir na diagonal após andar na vertical
            if (kickDir.x > 0)
                range = new Vector2(2.25f, -0.25f);
            else
                range = new Vector2(-2.25f, -0.25f);
        }
        else
        {
            if (kickDir.y > 0)
                range = new Vector2(0, 2.25f);
            else
                range = new Vector2(0, -2.25f);
        }

        //Pega a posição do player, soma o range e então armazena o alcance do chute
        kickRange = (Vector2)player.transform.position + range;   
        
    }
	
	// Update is called once per frame
	void Update () {

        //Leva a bola do player até a posição máxima de seu range
        transform.position = Vector3.MoveTowards(transform.position, kickRange, Time.deltaTime * ballSpeed);
	}
}
