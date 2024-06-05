using UnityEngine;

public class ElevacionPared : MonoBehaviour
{
    public float alturaMaxima = 7f; // Altura m�xima a la que se elevar� la pared
    public float velocidadElevacion = 2f; // Velocidad a la que se elevar� la pared
    public float tiempoElevacion = 10f; // Tiempo que la pared permanecer� elevada
    public float tiempoEntreElevaciones = 20f; // Tiempo entre cada elevaci�n de la pared

    private Vector3 posicionInicial;
    private bool estaElevandose = false;
    private bool estaBajando = false;

    private void Start()
    {
        posicionInicial = transform.position;
        InvokeRepeating("IniciarElevacion", tiempoEntreElevaciones, tiempoEntreElevaciones);
    }

    private void IniciarElevacion()
    {
        if (!estaElevandose && !estaBajando)
        {
            estaElevandose = true;
            Invoke("BajarPared", tiempoElevacion);
        }
    }

    private void Update()
    {
        if (estaElevandose)
        {
            // Elevar la pared hasta la altura m�xima
            transform.Translate(Vector3.up * velocidadElevacion * Time.deltaTime);

            if (transform.position.y >= posicionInicial.y + alturaMaxima)
            {
                estaElevandose = false;
            }
        }

        if (estaBajando)
        {
            // Bajar la pared de nuevo a su posici�n inicial
            transform.Translate(Vector3.down * velocidadElevacion * Time.deltaTime);

            if (transform.position.y <= posicionInicial.y)
            {
                estaBajando = false;
            }
        }
    }

    private void BajarPared()
    {
        estaBajando = true;
    }
}
