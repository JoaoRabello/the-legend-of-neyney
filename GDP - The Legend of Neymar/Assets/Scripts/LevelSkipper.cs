using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSkipper : MonoBehaviour {

    public int sceneTarget;
    private LevelChanger lvlChanger;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            lvlChanger = FindObjectOfType<LevelChanger>();
            lvlChanger.fadeToLevel(sceneTarget);
        }
    }
}
