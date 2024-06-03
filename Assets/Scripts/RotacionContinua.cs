using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    public float velocidadRotacion = 10f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto continuamente sobre su eje vertical
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
