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
            newColor = text.color;
            text.alpha = 0.0f;
            text.DOColor(newColor, TextDelayTime).SetEase(Ease.Linear);
            
        }
        catch (NullReferenceException)
        {
            // i dunno, we should never get here. maybe this try-catch doesnt have to be here in the
            // first place if i know for sure i will never not assign something to this script
        }
    }
}