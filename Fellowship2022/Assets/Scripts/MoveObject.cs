using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// this script moves objects (duh)
// transforms exclusively on the y axis

public class MoveObject : MonoBehaviour
{
    public GameObject Obj;
    public float DelayTime = 0.0f;
    float x, y;
    void Start()
    {
        try
        {
            x = Obj.transform.position.x;
            y = Obj.transform.position.y;
            TextSlideIn();
        }
        catch (UnassignedReferenceException)
        {
            // just in case theres nothing here
        }
    }

    // In order to give the appearance of text sliding into place, lower the inital y position of the specified
    // object (relative to the screen) by 10%. Then tween it back up to its original position. The DelayTime
    // variable can be adjusted in tandem with the FadeIn DelayTime for objects to appear at different times.
    public void TextSlideIn()
    {
            float temp = y - (0.05f * y);
            Obj.transform.position = new Vector2(x, temp);
            Obj.transform.DOMove(new Vector2(x, y), 1f).SetDelay(DelayTime);
    }
}
