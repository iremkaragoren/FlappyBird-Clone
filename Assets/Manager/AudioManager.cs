using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_WingSound;
    [SerializeField] private AudioClip m_DamageSound;
    [SerializeField] private AudioClip m_DeathSound;

    private AudioSource m_audioSource;

    //[SerializeField] private AudioSource _wing;
    //[SerializeField] private AudioSource _damage;
    //[SerializeField] private AudioSource _deadth;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        BirdDetector.OnDeathColliderIsTriggered += OnPipeTouchSound;
        BirdDetector.OnGroundColliderIsTriggered += OnGroundSound;
        BirdMovement.OnButtonPresed += OnWingSound;
    }
    
    private void OnWingSound()
    {
        m_audioSource.PlayOneShot(m_WingSound);
    }

    private void OnGroundSound()
    {
        m_audioSource.PlayOneShot(m_DeathSound);
    }

    private void OnPipeTouchSound()
    {
        m_audioSource.PlayOneShot(m_DamageSound);
    }
/*
    private void OnWingSound()
    {
        _wing.Play();
    }

    private void OnGroundSound()
    {
        _deadth.Play();
    }

    private void OnPipeTouchSound()
    {
        _damage.Play();
    }
    */

    private void OnDisable()
    {
        BirdDetector.OnDeathColliderIsTriggered -= OnPipeTouchSound;
        BirdDetector.OnGroundColliderIsTriggered -= OnGroundSound;
        BirdMovement.OnButtonPresed -= OnWingSound;
    }
}