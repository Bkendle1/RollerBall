using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//gameobject will have an audiosource component and you can't remove it    
[RequireComponent(typeof(AudioSource))]
public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int _coinValue = 10;
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    private bool _hasBeenPickedUp = false;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_hasBeenPickedUp)
        {
            _hasBeenPickedUp = true;
            GameManager.Instance.UpdateScore(_coinValue);
            _audioSource.PlayOneShot(_audioClip);
            Destroy(this.GetComponent<MeshRenderer>());
            DestroyAfterPickup();
        }
    }
    private void DestroyAfterPickup()
    {
        //Destroy the coin after the sfx plays
        Destroy(this.gameObject, _audioClip.length);
    }
    
    
}
