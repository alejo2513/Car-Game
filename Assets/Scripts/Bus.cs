using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{

    public GameObject cronometroGO; 
    public Cronometro cronometroScript;

    public GameObject audioFXGO;
    public AudioFx audioFXScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFXGO = GameObject.FindObjectOfType<AudioFx>().gameObject;
        audioFXScript = audioFXGO.GetComponent<AudioFx>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Carro>() != null)
        {
            audioFXScript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject); 
        }
    }
}
