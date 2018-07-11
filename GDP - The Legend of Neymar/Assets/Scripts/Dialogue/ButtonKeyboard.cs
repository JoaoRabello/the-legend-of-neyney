using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyboard : MonoBehaviour {

    [FMODUnity.EventRef]
    public string somClique;


    Button button;
    public Sprite oldSprite;
    public Sprite newSprite;
    Image image;

    public static bool canPress = false;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && canPress)
        {
            FMODUnity.RuntimeManager.PlayOneShot(somClique);
            image.sprite = newSprite;
            button.onClick.Invoke();
        } else if (Input.GetKeyUp(KeyCode.Space) && canPress)
                {
                    image.sprite = oldSprite;
                }
	}

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);
    }
}
