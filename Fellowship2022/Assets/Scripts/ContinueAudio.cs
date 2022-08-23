using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
   public string tagSpecification;
   public AudioSource boombox;
   private AudioClip currentBop;

   private void Awake()
    { 
        switch (tagSpecification)
       {
           case "Meet the Students":
               boombox = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Meet the Students Music") as AudioClip;
               boombox.clip = currentBop;
               break;
           case "Assembly Center":
               boombox = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Relocation Music") as AudioClip;
               boombox.clip = currentBop;
               break;
           case "War is Over":
               boombox = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Redress Music") as AudioClip;
               boombox.clip = currentBop;
               break;
       }
        DontDestroyOnLoad(this.gameObject);
    }
   private void Start()
    {
        boombox.Play();
    }
}
