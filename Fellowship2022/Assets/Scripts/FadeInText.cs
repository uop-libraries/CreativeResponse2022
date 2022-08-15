using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;
using UnityEngine.UI;

// FOR TEXT MESH PRO
// this script makes the specified object completely transparent on load,
// and then tweens back to solid visibility.
// (used together with the MoveObjext script)
public class FadeInText : MonoBehaviour
{
    public TMP_Text text;
    public float TextDelayTime = 0.5f;
    Color newColor;

    private void Start()
    {
        // for text mesh pro
        try
        {
            text.alpha = 0.0f;
            newColor.a = 1.0f;
            text.DOColor(newColor, TextDelayTime).SetEase(Ease.Linear);
            
        }
        catch (NullReferenceException)
        {

        }

        //var temp = Object.GetComponent<Image>().color;
        //temp.a = 0.0f;
        //newColor = Object.GetComponent<Image>().color;
        //newColor.a = 1.0f;
        //Object.GetComponent<Image>().DOColor(newColor, 0.5f).SetEase(Ease.Linear);
    }
}
