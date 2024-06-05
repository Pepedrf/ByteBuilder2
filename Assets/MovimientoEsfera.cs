using System;
using UnityEngine;

public class MovimientoEsfera : MonoBehaviour
{
    private float velocidad = 20f; // Velocidad de la esfera en unidades por segundo
    private float limiteTrasero = -20f;
    private float limiteDelantero = 20f;
    private bool direccion = true;
    private float tiempoAcumulado = 0f; // Acumula el tiempo pasado

    void Update()
    {
        // Incrementa el tiempo acumulado
        tiempoAcumulado += Time.deltaTime;

        // Incrementa la velocidad cada 60 segundos
        if (tiempoAcumulado >= 60f)
        {
            velocidad += 5f;
            tiempoAcumulado = 0f; // Reinicia el contador
        }

        // Verifica los límites y cambia la dirección
        if (transform.position.x < limiteTrasero)
        {
            direccion = false;
        }
        else if (transform.position.x > limiteDelantero)
        {
            direccion = true;
        }

        // Mueve la esfera
        if (direccion == false)
        {
            transform.Translate(Vector3.forward * -velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }
}
