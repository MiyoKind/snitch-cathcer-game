using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void StopMusicPlaying()
    {
        audioSource.Stop();
    }
}
