using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer Mixer;
    private bool audioState = true;
    private bool sfxState = true;

    public bool getAudioState() { return audioState; }
    public bool getSoundState() { return sfxState; }


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
