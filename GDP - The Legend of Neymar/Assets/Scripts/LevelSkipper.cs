using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkipper : MonoBehaviour {

    public int sceneTarget;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneTarget);
        }
    }
}
