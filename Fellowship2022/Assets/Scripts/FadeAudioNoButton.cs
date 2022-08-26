using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudioNoButton : MonoBehaviour
{
    private ContinueAudio theThing;
    public float audioDuration;
    public float targetVolume;

    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        StartCoroutine(theThing.StartFade(audioDuration, targetVolume));
    }

}
