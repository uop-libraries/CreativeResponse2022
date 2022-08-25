using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip currentEfx;
    private AudioSource soundEfx;
    public float setVolume;

    //will start immediately
    void Awake()
    {
        soundEfx = gameObject.AddComponent<AudioSource>();
        soundEfx.clip = currentEfx;
    }

    // Start is called before the first frame update
    void Start()
    {
        soundEfx.volume = setVolume;
        soundEfx.PlayOneShot(soundEfx.clip);
    }
}
