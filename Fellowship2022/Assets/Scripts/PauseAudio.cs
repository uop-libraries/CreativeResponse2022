using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
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
