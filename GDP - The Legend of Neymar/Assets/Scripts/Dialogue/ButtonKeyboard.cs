using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyboard : MonoBehaviour {

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeToColor(button.colors.pressedColor);
            button.onClick.Invoke();
        } else
            if (Input.GetKeyUp(KeyCode.Space))
            {
            FadeToColor(button.colors.normalColor);
        }
	}

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
