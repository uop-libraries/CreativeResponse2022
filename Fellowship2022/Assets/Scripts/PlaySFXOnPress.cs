using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXOnPress : MonoBehaviour
{
    [SerializeField] private AudioClip currentEfx;
    private AudioSource soundEfx;
    public float setVolume;

    void Awake()
    {
        soundEfx = gameObject.AddComponent<AudioSource>();
        soundEfx.clip = currentEfx;
    }

    public void PlaySFXOnPressFunct()
    {
        soundEfx.volume = setVolume;
        soundEfx.PlayOneShot(soundEfx.clip);
    }
}