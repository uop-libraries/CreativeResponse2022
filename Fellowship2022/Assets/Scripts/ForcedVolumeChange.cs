using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedVolumeChange : MonoBehaviour
{
    
    private ContinueAudio theThing;
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
    }

    public void ForceMute()
    {
        theThing.AdjustVolume(0f);
    }

    public void ForceUnmute()
    {
        theThing.AdjustVolume(1);
    }
}
