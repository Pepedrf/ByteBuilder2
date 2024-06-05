using System;
using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{
    private float velocidad = 10f; // Velocidad de la esfera en unidades por segundo
    private float velocidadNegativa = -10f; // Velocidad de la esfera en unidades por segundo
    private float limiteTrasero = -20f;
    private float limiteDelantero = 20f;
    Boolean direccion =true;

    void Update()
    {
        if (transform.position.x < limiteTrasero)
        {
            direccion=false;
        }
        else if (transform.position.x > limiteDelantero)
        {
            direccion= true;
        }

        if (direccion == false)
        {
            transform.Translate(Vector3.forward * velocidadNegativa * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }
}