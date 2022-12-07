using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFx : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip [] fxs;
    private AudioSource audioS;
    
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void FXSonidoChoque()
    {
        audioS.clip = fxs[0];
        audioS.Play(); 
    }

    public void FXMusic()
    {
        audioS.clip = fxs[1];
        audioS.Play();
    }
}
