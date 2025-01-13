using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip disparoClip;

    public void ReproducirSonidoDisparo()
    {
        audioSource.PlayOneShot(disparoClip);
    }
}
