using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public AudioClip newTrack;
    private ContinueAudio theThing;
    
    //notice: I know this is exactly the same as change audio, this is just my scuffed way of working
    // around the whole changing audio on start and preloading a clip issue. this is only to be used in
    // the title scene. DO NOT AND I REPEAT DO NOT PUT THIS ANYWHERE ELSE. ty <3
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        theThing.ChangeBGM(newTrack);
    }
}
