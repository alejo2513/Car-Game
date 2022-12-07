using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray; 
    
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;


    private int contadorCalles = 0;
    private int numeroSelectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamañoCalle;

    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;
    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject carroGO;
    public GameObject audioFXGO;
    public AudioFx audioFXScript;
    public GameObject bgFinalGO; 
    void Start()
    {
        InicioJuego();
    }

    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("Main Camera");
        mCamComp = mCamGo.GetComponent<Camera>();

        bgFinalGO = GameObject.Find("PanelGameOver"); 
        bgFinalGO.SetActive(false);
        
        audioFXGO= GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFx>();

        carroGO = GameObject.FindObjectOfType<Carro>();  
        
        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
    }

    public void JuegoTerminadoEstados()
    {
        carroGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGO.SetActive(true);
    }
    void VelocidadMotorCarretera()
    {
        velocidad = 15;
    }

    void BuscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        for (int i = 0; i < contenedorCallesArray.Length; i++)
        {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        CrearCalle();
    }

    void CrearCalle()
    {
        contadorCalles ++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);
        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x,
            calleAnterior.transform.position.y + tamañoCalle, 0);

        salioDePantalla = false;
    }

    void MidoCalle()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<PiezaCalle>() != null)
            {
                float tamañoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds
                    .size.y;
                tamañoCalle = tamañoCalle + tamañoPieza; 
            }
        }
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCamComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            if (calleAnterior.transform.position.y + tamañoCalle < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoCalles();
            }
        }

  
        
    }

    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        tamañoCalle = 0;
        calleAnterior = null;
        CrearCalle();
    }
}
