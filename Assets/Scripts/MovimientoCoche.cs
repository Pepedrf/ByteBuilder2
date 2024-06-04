using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad del coche en unidades por segundo

    void Update()
    {
        // Mover el coche en línea recta hacia adelante (eje Z local)
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
