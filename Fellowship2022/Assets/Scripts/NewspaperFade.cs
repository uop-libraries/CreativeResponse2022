using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewspaperFade : MonoBehaviour
{
    public GameObject FadedBackground, Button;
    public TMP_Text text;
    public Button ArticleButton;
    private Image BGimg, Bttnimg;
    private float alpha;
    

    void Start()
    {
        BGimg = FadedBackground.GetComponent<Image>();
        Bttnimg = Button.GetComponent<Image>();
        BGimg.CrossFadeAlpha(0f, 0f, false);
        text.alpha = 0f;
    }
    public void ShowArticleText()
    {
        BGimg.CrossFadeAlpha(1.0f, 0.0f, false);
        Bttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        text.alpha = 255f;
    }
}
