using UnityEngine;

public class CameraMovement : MonoBehaviour {


    [SerializeField]
    private Vector3 recuo;

    [SerializeField]
    private Transform alvo;

    Player player;

    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    //Variáveis para controle de bordas com a câmera
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    


    void Start() {
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        player = FindObjectOfType<Player>();
        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if (player.isAlive)
        {
            //Muda a posição da câmera para a posição do objeto alvo (em geral o player) e soma ao recuo para evitar que a câmera fique dentro do objeto
            transform.position = alvo.position + recuo;

            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
        

        
	}

    public void SetBounds(BoxCollider2D newBounds) {

        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }

}
