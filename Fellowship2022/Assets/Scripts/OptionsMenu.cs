using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer Mixer;
    private GameObject musicToggle;
    private GameObject sfxToggle;
    private bool musicState = true;
    private bool sfxState = true;
    private float currVolume;
    private static float on = 0.0f;
    private static float off = -80.0f;

    void Awake()
    {
        musicToggle = GameObject.Find("Toggle - Music");
        sfxToggle = GameObject.Find("Toggle - SFX");
        reloadAudioState();

        musicToggle.GetComponent<Toggle>().isOn = getMusicState();
        sfxToggle.GetComponent<Toggle>().isOn = getSoundState();
    }

    public bool getMusicState()
    {
        reloadAudioState();
        return musicState;
    }

    public bool getSoundState()
    {
        reloadAudioState();
        return sfxState;
    }

    private void reloadAudioState()
    {
        Mixer.GetFloat("MusicMasterVol", out currVolume);
        if (currVolume == on)
        {
            musicState = true;
        }
        else if (currVolume == off)
        {
            musicState = false;
        }

        Mixer.GetFloat("SFXMasterVol", out currVolume);
        if (currVolume == on)
        {
            sfxState = true;
        }
        else if (currVolume == off)
        {
            sfxState = false;
        }
    }

    void Start()
    {
        //reloadAudioState();
    }

    public void toggleMusicEnabled()
    {
        if (musicState)
        {
            Mixer.SetFloat("MusicMasterVol", -80.0f);
            musicState = false;
        }
        else
        {
            Mixer.SetFloat("MusicMasterVol", 0.0f);
            musicState = true;
        }
    }

    public void toggleSFXEnabled()
    {
        if (sfxState)
        {
            Mixer.SetFloat("SFXMasterVol", -80.0f);
            sfxState = false;
        }
        else
        {
            Mixer.SetFloat("SFXMasterVol", 0.0f);
            sfxState = true;
        }
    }
}