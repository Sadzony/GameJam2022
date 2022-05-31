using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactMaker : MonoBehaviour
{
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
