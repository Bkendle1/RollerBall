using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private AudioClip deathSFX;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has hit kill zone");
            other.gameObject.GetComponent<AdvancedInput>().ResetPlayer();
            GameManager.Instance.UpdateLives(-1);
            _audioSource.PlayOneShot(deathSFX);
        }
    }
}
