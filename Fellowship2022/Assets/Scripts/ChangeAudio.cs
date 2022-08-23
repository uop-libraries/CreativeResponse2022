using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public AudioClip newTrack;
    private ContinueAudio theThing;
    // Start is called before the first frame update
    void Awake()
    {
        theThing = FindObjectOfType<ContinueAudio>();
        theThing.ChangeBGM(newTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
