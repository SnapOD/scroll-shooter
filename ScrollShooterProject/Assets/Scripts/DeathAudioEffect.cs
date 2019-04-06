using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DeathAudioEffect : MonoBehaviour
{
    public AudioClip clip;
    HealthComponent healthComponent;
    void Start()
    {
        healthComponent = GetComponentInChildren<HealthComponent>();
        healthComponent.DeathEvent += HealthComponent_DeathEvent;
    }
    private void HealthComponent_DeathEvent()
    {
        GameObject gameObject = new GameObject();
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = 0.2f;
        audioSource.Play();
        Destroy(gameObject, clip.length);
    }
}
