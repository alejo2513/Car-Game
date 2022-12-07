using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Cronometro : MonoBehaviour
{

    public GameObject motorCarreterasGo;
    public MotorCarreteras MotorCarreterasScript;
    
    public float tiempo;
    public float distancia;

    public Text txtTiempo;
    public Text txtDistancia;

    public Text txtDistanciaFinal;
    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGo = GameObject.Find("MotorCarreteras");
        MotorCarreterasScript = motorCarreterasGo.GetComponent<MotorCarreteras>();

        txtTiempo.text = "2:00";
        txtDistancia.text = "0"; 

    }

    // Update is called once per frame
    void Update()
    {
        if (MotorCarreterasScript.inicioJuego == true && MotorCarreterasScript.juegoTerminado == false)
        {
            CalculoTiempoDistancia();
        }

        if (tiempo <= 0 && MotorCarreterasScript.juegoTerminado == false) ;
        {
            MotorCarreterasScript.juegoTerminado = true;
            MotorCarreterasScript.JuegoTerminadoEstados();
            txtDistanciaFinal.text = ((int) distancia).ToString() + "M";
            txtTiempo.text = "0:00"; 
        }
        
    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * MotorCarreterasScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int) tiempo / 60;
        int segundos = (int) tiempo % 60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0'); 

    }
}
