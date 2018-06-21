using UnityEngine;

public class CameraMovement : MonoBehaviour {


    [SerializeField]
    private Vector3 recuo;

    [SerializeField]
    private Transform alvo;


    public BoxCollider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    //Variáveis para controle de bordas com a câmera
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    //public int cont = 1;

    void Start() {
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update () {
        //Muda a posição da câmera para a posição do objeto alvo (em geral o player) e soma ao recuo para evitar que a câmera fique dentro do objeto
        transform.position = alvo.position + recuo;

        /*if (boundBox == null)
        {
            boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
            minBounds = boundBox.bounds.min;
            maxBounds = boundBox.bounds.max;
        }*/
        //if (cont == 1)
        //{
            float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
            float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        //}
        
	}

    public void SetBounds(BoxCollider2D newBounds) {

        boundBox = newBounds;

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;
    }

}
