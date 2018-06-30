using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyboard : MonoBehaviour {

    Button button;
    public Sprite oldSprite;
    public Sprite newSprite;
    Image image;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //FadeToColor(button.colors.pressedColor);
            image.sprite = newSprite;
            button.onClick.Invoke();
        } else if (Input.GetKeyUp(KeyCode.Space))
                {
                    image.sprite = oldSprite;
                    //FadeToColor(button.colors.normalColor);
                }
	}

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
