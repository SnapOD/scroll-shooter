using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ShotSoundEffect : MonoBehaviour
{
    public AudioClip clip;
    ShootComponent shootComponent;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shootComponent = GetComponent<ShootComponent>();
        shootComponent.ShotEvent += ShootComponent_ShotEvent;
        audioSource.clip = clip;
    }
    private void ShootComponent_ShotEvent()
    {
        audioSource.Play();
    }
}
