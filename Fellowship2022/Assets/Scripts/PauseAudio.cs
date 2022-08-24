using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    //TODO adding comment for the sake of updating branch to fix merge error in main, delete after
    private ContinueAudio theThing;
    // Start is called before the first frame update

    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
    }

    public void PlayBop()
    {
        theThing.PlayAudio();
    }

    public void StopBop()
    {
        theThing.PauseAudio();
    }
}
