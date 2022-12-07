using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCarro : MonoBehaviour
{
    public GameObject carroGO; 
    public float anguloDeGiro;
    public float velocidad; 
    
    void Start()
    {
        carroGO = GameObject.FindObjectOfType<Carro>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        float giroEnZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal")* velocidad * Time.deltaTime);
        giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro; 
        carroGO.transform.rotation = Quaternion.Euler(0,0, giroEnZ);
    }
}
