using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

// For the newspaper pages of El Joaquin
// shows the user where to tap and it shows the text mayu and george provided (ty)
// im tired and this is terribly written im sowwy but we prolly dont have to revisit this anyways
// cause its only on 6 pages
public class NewspaperFade : MonoBehaviour
{
    public GameObject FadedBackground, ArticleButton, ContinueButton, BackButton, PonchoObj;
    public TMP_Text SubTitleText, TitleText, contenttext, bttntext, bttntext2, metadata;
    private Image BGimg, ArtBttnimg, CntBttnimg, BckBttnimg, PonchoImg;
    //private float temp;
    private Color tempColor;

    
    void Start()
    {
        BGimg = FadedBackground.GetComponent<Image>();
        ArtBttnimg = ArticleButton.GetComponent<Image>();
        CntBttnimg = ContinueButton.GetComponent<Image>();
        BckBttnimg = BackButton.GetComponent<Image>();
        PonchoImg = PonchoObj.GetComponent<Image>();
        //temp = ArtBttnimg.color.a;
        tempColor = new Color(ArtBttnimg.color.r, ArtBttnimg.color.g, ArtBttnimg.color.b, 0.0f);
        ArtBttnimg.DOColor(tempColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
        BGimg.CrossFadeAlpha(0.0f, 0.0f, false);
        CntBttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        BckBttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        PonchoImg.CrossFadeAlpha(0.0f, 0.0f, false);
        contenttext.alpha = 0.0f;
        bttntext.alpha = 0.0f;
        bttntext2.alpha = 0.0f;
        metadata.alpha = 0.0f;
        TitleText.alpha = 0.0f;
        SubTitleText.alpha = 0.0f;
    }
    public void ShowArticleText()
    {
        BGimg.CrossFadeAlpha(1.0f, 0.0f, false);
        //DOTween.Kill(ArtBttnimg);
        ArtBttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        CntBttnimg.CrossFadeAlpha(1.0f, 0.0f, false);
        BckBttnimg.CrossFadeAlpha(1.0f, 0.0f, false);
        PonchoImg.CrossFadeAlpha(1.0f, 0.0f, false);
        contenttext.alpha = 255f;
        bttntext.alpha = 255f;
        bttntext2.alpha = 255f;
        metadata.alpha = 255.0f;
        TitleText.alpha = 255f;
        SubTitleText.alpha = 255f;
    }

    public void HideArticleText()
    {
        BGimg.CrossFadeAlpha(0.0f, 0.0f, false);
        ArtBttnimg.CrossFadeAlpha(1.0f, 0.0f, false);
        //ArtBttnimg.DOColor(tempColor, 0.5f).SetLoops(-1, LoopType.Yoyo);
        CntBttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        BckBttnimg.CrossFadeAlpha(0.0f, 0.0f, false);
        PonchoImg.CrossFadeAlpha(0.0f, 0.0f, false);
        contenttext.alpha = 0f;
        bttntext.alpha = 0f;
        bttntext2.alpha = 0f;
        metadata.alpha = 0.0f;
        TitleText.alpha = 0.0f;
        SubTitleText.alpha = 0.0f;
    }
}
