using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXOnPress : MonoBehaviour
{
    private SFXAudioMain soundEfx;
    public AudioClip effectToPlay;
    public float volume;

    void Awake()
    {
        soundEfx = FindObjectOfType<SFXAudioMain>();
    }

    public void PlaySFXOnPressFunct()
    {
        soundEfx.setVolume(volume);
        soundEfx.PlayAudio(effectToPlay);
    }
}