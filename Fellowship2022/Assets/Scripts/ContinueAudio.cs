using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
    public AudioSource boombox;
    public float duration;
   
   private void Awake()
   {
       GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Agony");
       if (musicObj.Length > 1)
       {
           Destroy(this.gameObject);
       }
       DontDestroyOnLoad(this.gameObject);
    }
   private void Start()
    {
        boombox.Play();
    }

   public void ChangeBGM(AudioClip ssong)
   {
       boombox.DOFade(0, duration);
       boombox.Stop();
       boombox.clip = ssong;
       boombox.Play();
       boombox.DOFade(1, duration);
   }

   public void AdjustVolume(float volumeLevel)
   {
       boombox.volume = volumeLevel;
   }

   public void PauseAudio()
   {
       boombox.Pause();
   }

   public void PlayAudio()
   {
       boombox.Play();
   }
   
   public string GetCurrentTrack()
   {
       return boombox.clip.ToString();
   }
   
   public IEnumerator StartFade(float duration, float targetVolume)
   {
       float currentTime = 0;
       float start = boombox.volume;
       while (currentTime < duration)
       {
           currentTime += Time.deltaTime;
           boombox.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
           yield return null;
       }
       yield break;
   }
}
