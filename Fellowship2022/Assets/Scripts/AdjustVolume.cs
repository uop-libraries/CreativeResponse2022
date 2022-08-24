using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustVolume : MonoBehaviour
{
    private ContinueAudio theThing;
    public float volumeIntensity;

    //this will change the volume to whatever is directly specified in the enter field on the script
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        theThing.AdjustVolume(volumeIntensity);
    }
}
