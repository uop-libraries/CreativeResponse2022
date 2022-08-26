using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    private SFXAudioMain soundEfx;
    public AudioClip effectToPlay;
    public float volume;

    //will start immediately
    void Awake()
    {
        soundEfx = FindObjectOfType<SFXAudioMain>();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundEfx.setVolume(volume);
        soundEfx.PlayAudio(effectToPlay);
    }
}
