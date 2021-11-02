using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoA : MonoBehaviour
{
    public Text mensaje;
    private GameObject jugador;
    public float distanciaPorDefecto;

    // Start is called before the first frame update
    void Start()
    {
        jugador = null;
        distanciaPorDefecto = 5;
        Jugador.EventoA += Mensaje;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() 
    {
        jugador = GameObject.Find("Jugador");
        if(jugador == null) {
            return;
        }
        float distanciaJugador = Vector3.Distance(jugador.transform.position, transform.localPosition);
        if (distanciaJugador < distanciaPorDefecto) {
            Jugador.AcercamientoA();
        }
    }

    void Mensaje() 
    {
        mensaje.text = "Colisión del objeto B";
    }

    void OnCollisionEnter(Collision objetoColision)
    {
        if(objetoColision.gameObject.tag == "Jugador") {
            Jugador.colisionA();
        }
    }
}
