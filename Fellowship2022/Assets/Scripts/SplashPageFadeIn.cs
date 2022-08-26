using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
// This fades in assigned gameobjects at different times. Initializes them as invisible and fades the in
// one after another. A simple thing but it looks pretty nice. Pretty proud.
public class SplashPageFadeIn : MonoBehaviour
{
    public GameObject SplashImgObj, ButtonImgObj, StringImgObj;
    public TMP_Text ContentText, ContextText2, ContextText3, ButtonText;
    private Image SplashImg, ButtonImg, StringImg;
    private Color newColor, newColor1, newColor2, newColor3;


    public void Awake()
    {
        newColor = ButtonText.color;
        ButtonText.alpha = 0.0f;
        newColor1 = ContentText.color;
        ContentText.alpha = 0.0f;
        newColor2 = ContextText2.color;
        ContextText2.alpha = 0.0f;
        newColor3 = ContextText3.color;
        ContextText3.alpha = 0.0f;

        SplashImg = SplashImgObj.GetComponent<Image>();
        ButtonImg = ButtonImgObj.GetComponent<Image>();
        StringImg = StringImgObj.GetComponent<Image>();

        SplashImg.CrossFadeAlpha(0, 0f, false);
        ButtonImg.CrossFadeAlpha(0, 0f, false);
        StringImg.CrossFadeAlpha(0, 0f, false);

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SplashImg.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        ContentText.DOColor(newColor1, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        ContextText2.DOColor(newColor2, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        ContextText3.DOColor(newColor3, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.0f);
        ButtonImg.CrossFadeAlpha(1, 1f, false);
        ButtonText.DOColor(newColor, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        StringImg.CrossFadeAlpha(1, 1f, false);
    }
}
