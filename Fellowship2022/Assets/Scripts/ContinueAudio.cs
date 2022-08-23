using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
    public AudioSource boombox;
   
   private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
   private void Start()
    {
        boombox.Play();
    }

   public void ChangeBGM(AudioClip ssong)
   {
       boombox.Stop();
       boombox.clip = ssong;
       boombox.Play();
   }
}
