using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    private ContinueAudio theThing;
    public float volumeIntensity;

    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        theThing.AdjustVolume(volumeIntensity);
    }
}
