using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

// For the newspaper pages of El Joaquin and Rohwer Outpost.
// shows the user where to tap and it shows the text mayu and george provided (ty)
// im tired and this is terribly written im sowwy.
// the button to continue to the next page is invisible and can still be tapped on to change scenes if the 
// user taps in position its at. surely nobody would tap anywhere other than the flashing square button
// indicating where to tap ...right?
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

        tempColor = new Color(ArtBttnimg.color.r, ArtBttnimg.color.g, ArtBttnimg.color.b, 0.0f);

        // flash the button on the article the user needs to tap
        ArtBttnimg.DOColor(tempColor, 0.5f).SetLoops(-1, LoopType.Yoyo);

        // initially set everything that pops up when tapping the article button invisible.
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
    // When the user taps the article button, show everything that was initially set invisible. 
    // Also dim the background newpaper image to make things easier to read and see.
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
    // When the user taps the back button, hide everything that showed up in ShowArticleText()
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
