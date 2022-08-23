using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
   public string tagSpecification;
   private AudioSource audio;
   private AudioClip currentBop;

   private void Awake()
    {
        switch (tagSpecification)
       {
           case "Meet the Students":
               audio = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Meet the Students Music") as AudioClip;
               audio.clip = currentBop;
               break;
           case "Assembly Center":
               audio = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Relocation Music") as AudioClip;
               audio.clip = currentBop;
               break;
           case "War is Over":
               audio = this.GetComponent<AudioSource>();
               currentBop = Resources.Load("Bops/Redress Music") as AudioClip;
               audio.clip = currentBop;
               break;
       }
    }

   private void Start()
    {
        audio.Play();
    }

   private void WhatPlayin()
   {
       if (tagSpecification == "Meet the Students")
       {
       }
   }
}
