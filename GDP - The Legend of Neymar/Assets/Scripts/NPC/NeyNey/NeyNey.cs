using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeyNey : MonoBehaviour {

    public Transform waypoint;
    public Transform fuleco;
    public FulecoCutscene fulecoCuts;
    public CameraMove cam;
    private Animator anim;

    private bool canMove = true;
    int i = 0;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<CameraMove>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("andando", true);
        if (canMove)
            transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, 2 * Time.deltaTime);
        if(transform.position == waypoint.transform.position && i == 0)
        {
            GetComponent<NPCDialogue>().canDialogue = true;
            i++;
            StartCoroutine(caindo());
        }
        if(cam.transform.position.x == fuleco.transform.position.x && cam.transform.position.y == fuleco.transform.position.y)
        {
            fulecoCuts.canTalk = true;
        }
	}

    IEnumerator caindo()
    {
        canMove = false;
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("caindo", true);
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("deitado", true);
        yield return new WaitForSeconds(0.3f);
        cam.alvo = fuleco;
    }
}
