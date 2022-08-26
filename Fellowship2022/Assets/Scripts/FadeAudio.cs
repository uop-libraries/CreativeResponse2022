using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudio : MonoBehaviour
{
    private ContinueAudio theThing;
    public float audioDuration;
    public float targetVolume;

    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
    }

    public void fadeAudioToVal()
    {
        StartCoroutine(theThing.StartFade(audioDuration, targetVolume));
    }
}
