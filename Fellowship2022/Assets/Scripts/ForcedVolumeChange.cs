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
    
    //TODO send help plz

    public void ForceMute()
    {
        Debug.Log("muting audio");
        theThing.AdjustVolume(0f);
        Debug.Log("volume is now: " + theThing.GetComponent<AudioSource>().volume);
    }

    public void ForceUnmute()
    {
        theThing.AdjustVolume(1);
    }
}
