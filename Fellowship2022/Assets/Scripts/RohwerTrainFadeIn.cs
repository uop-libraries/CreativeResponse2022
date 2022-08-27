using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
// This fades in assigned gameobjects at different times. Initializes them as invisible and fades the in
// one after another. A simple thing but it looks pretty nice. Pretty proud.
public class RohwerTrainFadeIn : MonoBehaviour
{
    public GameObject RohwerImgObj, ButtonObj;
    public TMP_Text ContentText, ContextText2, ButtonText;
    private Image RohwerImg, ButtonImg;
    private Color newColor;


    public void Awake()
    {
        newColor = ButtonText.color;
        ButtonText.alpha = 0.0f;
        ContentText.alpha = 0.0f;
        ContextText2.alpha = 0.0f;

        RohwerImg = RohwerImgObj.GetComponent<Image>();
        ButtonImg = ButtonObj.GetComponent<Image>();

        RohwerImg.CrossFadeAlpha(0, 0f, false);
        ButtonImg.CrossFadeAlpha(0, 0f, false);

        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        RohwerImg.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        ContentText.DOColor(newColor, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1);
        ContextText2.DOColor(newColor, 1.0f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1);
        ButtonImg.CrossFadeAlpha(1, 1f, false);
        ButtonText.DOColor(newColor, 1.0f).SetEase(Ease.Linear);
    }
}
