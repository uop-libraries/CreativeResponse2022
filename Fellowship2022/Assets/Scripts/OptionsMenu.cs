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
    private bool audioState = true;
    private bool sfxState = true;
    private float currVolume;
    private static float on = 0.0f;
    private static float off = -80.0f;

    public bool getMusicState()
    {
        reloadAudioState();
        return audioState;
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
            audioState = true;
        }
        else if (currVolume == off)
        {
            audioState = false;
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

    void Awake()
    {
        musicToggle = GameObject.Find("Toggle - Test");
        sfxToggle = GameObject.Find("Toggle - SFX");
        reloadAudioState();

        musicToggle.GetComponent<Toggle>().isOn = getMusicState();
        sfxToggle.GetComponent<Toggle>().isOn = getSoundState();

        //DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //Debug.Log("The music switch is: " + this.gameObject.GetComponent<Toggle>().isOn);
        //Debug.Log("But the music playing is: " + audioState);
    }

    public void toggleMusicEnabled()
    {
        if (audioState)
        {
            Mixer.SetFloat("MusicMasterVol", -80.0f);
            audioState = false;
        }
        else
        {
            Mixer.SetFloat("MusicMasterVol", 0.0f);
            audioState = true;
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