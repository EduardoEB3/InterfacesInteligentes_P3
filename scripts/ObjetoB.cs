using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoB : MonoBehaviour
{
    public Text mensaje;
    private Rigidbody rb;
    private Renderer render;
    private Transform objetivo;
    private GameObject jugador;
    private GameObject esferaMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        jugador = null;
        esferaMovimiento = null;
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        Jugador.EventoB += Fuerza;
        Jugador.acercamientoA += Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fuerza() {
        mensaje.text = "";
        rb.mass += 10;
    }

    void Color() {
        Color col = new Color(Random.value, Random.value, Random.value);
        render.material.color = col;

        jugador = GameObject.Find("Jugador");
        esferaMovimiento = GameObject.Find("EsferaMovimiento");
        if (jugador == null || esferaMovimiento == null) {
           return;
        }
        esferaMovimiento.transform.LookAt(jugador.transform.position);
        Color colorDraw = new Color(255, 0, 0);
        Debug.DrawRay(esferaMovimiento.transform.position, jugador.transform.position - esferaMovimiento.transform.position, colorDraw);
    }

    void OnCollisionEnter(Collision objetoColision)
    {
        if(objetoColision.gameObject.tag == "Jugador") {
            Jugador.colisionB();
        }
    }

}
