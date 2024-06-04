using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    public float velocidadRotacion = 15f; // Velocidad de rotaci�n en grados por segundo
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde el �ltimo cambio de direcci�n
    private bool rotandoPositivo = true; // Direcci�n actual de la rotaci�n (true = positivo, false = negativo)
    private float intervaloCambioDireccion = 60f; // Intervalo de tiempo en segundos para cambiar la direcci�n

    void Update()
    {
        // Incrementar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Verificar si es tiempo de cambiar la direcci�n de rotaci�n
        if (tiempoTranscurrido >= intervaloCambioDireccion)
        {
            // Cambiar la direcci�n de rotaci�n
            rotandoPositivo = !rotandoPositivo;
            // Reiniciar el temporizador
            tiempoTranscurrido = 0f;
        }

        // Calcular la direcci�n de rotaci�n actual
        float direccionRotacion = rotandoPositivo ? 1f : -1f;

        // Rotar el objeto continuamente sobre su eje vertical
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime * direccionRotacion);
    }
}
