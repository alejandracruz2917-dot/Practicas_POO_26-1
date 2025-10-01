using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Transform CamaraPrincipal;

    public Rigidbody rb;

    //Variable para apuntar
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo= -2f;
    public float limiteDerecho = 2f;


    public float fuerzaDeLanzamiento = 1000f;

    private bool haSidoLanzada = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { //Expresion: mientras que haSidoLanzado sea falso puedes disparar
        if (haSidoLanzada==false)
        {
            Apuntar();
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Lanzar();  
        }

        }

    }

    void Apuntar()
    {
        //1. leer un inpunt Horizontal de tipo axis te permite registrar 
        //entradas con las teclas A,D, y Flecha izquierda y flecha derecha
        float inputHorizontal = Input.GetAxis("Horizontal");

        //2. mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        //3. Delimitar el movimiento de la bola
        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;
    }


    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        if(CamaraPrincipal != null)
        {
            CamaraPrincipal.SetParent(transform);
        }
    }

}// Bienvenidos a la entrada del infierno
