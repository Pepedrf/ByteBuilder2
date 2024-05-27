using UnityEngine;
using TMPro;

public class MesaEntrega : MonoBehaviour
{
    public TextMeshProUGUI puntuacionText; // Referencia al objeto Text(TMP) en el Canvas
    private int puntos = 0; // Variable para almacenar los puntos del jugador
    private float intervalo = 0.5f; // Intervalo en segundos para buscar objetos
    private float tiempoTranscurrido = 0f;

    // Update is called once per frame
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime; // Aumentar el tiempo transcurrido

        // Verificar si ha pasado el intervalo de tiempo
        if (tiempoTranscurrido >= intervalo)
        {
            tiempoTranscurrido = 0f; // Reiniciar el tiempo transcurrido
            BuscarObjetosHijos();
        }
    }

    private void BuscarObjetosHijos()
    {
        int activaMensaje = 1;

        Transform[] objetosHijos = GetComponentsInChildren<Transform>(true);

        for (int i = 1; i < objetosHijos.Length; i++)
        {
            if (objetosHijos.Length > activaMensaje)
            {
                Debug.Log("Has entregado " + objetosHijos[i].name);
                Destroy(objetosHijos[i].gameObject);
                activaMensaje++;

                // Sumar puntos y actualizar el texto de la puntuación
                puntos += 5;
                ActualizarPuntuacion();
            }
        }
    }

    private void ActualizarPuntuacion()
    {
        puntuacionText.text = "Puntos: " + puntos;
    }
}
