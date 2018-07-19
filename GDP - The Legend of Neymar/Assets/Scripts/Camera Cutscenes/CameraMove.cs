using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform alvo;
    public Vector3 recuo;
    public float speed;

	// Update is called once per frame
	void Update () {

        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position + recuo, speed * Time.deltaTime);

    }
}
