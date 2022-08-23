using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
   public string tagSpecification;
   private AudioSource boombox;
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

   private void ChangeBop()
   {
       if (GameObject.FindGameObjectWithTag("Meet the Students"))
       {
           tagSpecification = "Meet the Students";
           boombox = this.GetComponent<AudioSource>();
           currentBop = Resources.Load("Bops/Meet the Students Music") as AudioClip;
           Debug.Log("Now playing: " + currentBop);
           boombox.clip = currentBop;
       }
       else if (GameObject.FindGameObjectWithTag("Assembly Center"))
       {
           tagSpecification = "Assembly Center";
           boombox = this.GetComponent<AudioSource>();
           currentBop = Resources.Load("Bops/Meet the Students Music") as AudioClip;
           Debug.Log("Now playing: " + currentBop);
           boombox.clip = currentBop;
       }
       else if (GameObject.FindGameObjectWithTag("War is Over"))
       {
           tagSpecification = "War is Over";
           boombox = this.GetComponent<AudioSource>();
           currentBop = Resources.Load("Bops/Meet the Students Music") as AudioClip;
           Debug.Log("Now playing: " + currentBop);
           boombox.clip = currentBop;
       }
   }

   private void FixedUpdate()
   {
       ChangeBop();
   }
}
