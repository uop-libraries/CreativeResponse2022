using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public AudioClip newTrack;
    private static ContinueAudio theThing;
    // Start is called before the first frame update
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();

        //Debug.Log("the boombox has:" + theThing.GetCurrentTrack());
        //Debug.Log("the newtrack suggested is: " + newTrack);
        if (theThing.GetCurrentTrack() != newTrack.ToString())
        {
            theThing.ChangeBGM(newTrack);
        }
    }
}
