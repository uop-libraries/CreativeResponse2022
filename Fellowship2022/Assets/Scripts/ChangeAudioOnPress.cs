using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioOnPress : MonoBehaviour
{
    public AudioClip newTrack;
    private ContinueAudio theThing;

    public void ChangeAudioFunct()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        Debug.Log("the boombox has:" + theThing.GetCurrentTrack());
        Debug.Log("the newtrack suggested is: " + newTrack);
        if (theThing.GetCurrentTrack() != newTrack.ToString())
        {
            theThing.ChangeBGM(newTrack);
        }
    }
}
