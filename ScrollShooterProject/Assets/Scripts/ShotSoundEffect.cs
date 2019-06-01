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
        shootComponent = GetComponent<ShootComponent>();
        if (shootComponent == null)
            return;
        shootComponent.ShotEvent += ShootComponent_ShotEvent;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
    }
    private void ShootComponent_ShotEvent()
    {
        audioSource.Play();
    }
}
