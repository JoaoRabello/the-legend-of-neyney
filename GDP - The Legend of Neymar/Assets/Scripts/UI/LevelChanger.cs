using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator anim;
    private int level;
	

    public void fadeToLevel(int index)
    {
        level = index;
        anim.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(level);
    }
}
