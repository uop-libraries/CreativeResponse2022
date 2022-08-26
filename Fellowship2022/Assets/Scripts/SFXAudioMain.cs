using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class SFXAudioMain : MonoBehaviour
{
    public AudioSource sfxAudio;

    private void Awake()
    {
        GameObject[] sfxObj = GameObject.FindGameObjectsWithTag("SFX");
        if (sfxObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void PauseAudio()
    {
        sfxAudio.Pause();
    }

    public void PlayAudio(AudioClip sfx)
    {
        sfxAudio.clip = sfx;
        sfxAudio.Play();
    }

    public void setVolume(float volume)
    {
        sfxAudio.volume = volume;
    }

    public string GetCurrentTrack()
    {
        return sfxAudio.clip.ToString();
    }
}
