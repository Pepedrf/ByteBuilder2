using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    public float velocidadRotacion = 15f; // Velocidad de rotación en grados por segundo
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde el último cambio de dirección
    private bool rotandoPositivo = true; // Dirección actual de la rotación (true = positivo, false = negativo)
    private float intervaloCambioDireccion = 60f; // Intervalo de tiempo en segundos para cambiar la dirección

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si es tiempo de cambiar la dirección de rotación
        if (tiempoTranscurrido >= intervaloCambioDireccion)
        {
            // Cambiar la dirección de rotación
            rotandoPositivo = !rotandoPositivo;
            // Reiniciar el temporizador
            tiempoTranscurrido = 0f;
        }

        // Calcular la dirección de rotación actual
        float direccionRotacion = rotandoPositivo ? 1f : -1f;

        // Rotar el objeto continuamente sobre su eje vertical
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime * direccionRotacion);
    }
}
