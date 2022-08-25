using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudio : MonoBehaviour
{
    private ContinueAudio theThing;
    public float audioDuration;
    
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        StartCoroutine(theThing.StartFade(audioDuration, 1));
    }
}
