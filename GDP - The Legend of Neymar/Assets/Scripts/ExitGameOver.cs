using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGameOver : MonoBehaviour {

    public Image seta1;
    public Image seta2;
    private bool opt1 = true;

    private void Start()
    {
        seta2.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            trocaOpcao();
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.V))
        {
            if (opt1)
            {
                GaviaoControl.canGiveBallCont = 0;
                NightmareControl.killNightmare = false;
                Player.bolaRecebida = false;
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }

        }
	}


    void trocaOpcao()
    {
        if (opt1)
        {
            opt1 = false;
            seta1.enabled = false;
            seta2.enabled = true;
        }
        else
        {
            opt1 = true;
            seta1.enabled = true;
            seta2.enabled = false;
        }
    }
}
