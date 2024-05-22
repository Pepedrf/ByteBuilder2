using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MesaLimpieza : MonoBehaviour
{
    public Transform UbicacionObjeto; // La ubicación donde se coloca el objeto para limpiarse
    public BarraProgreso barraProgreso; // Referencia a la barra de progreso
    private GameObject objetoActual;
    private bool limpiando = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!limpiando && collision.gameObject.CompareTag("Objeto"))
        {
            objetoActual = collision.gameObject;
            ObjetoLimpieza objetoLimpieza = objetoActual.GetComponent<ObjetoLimpieza>();

            if (objetoLimpieza != null && !objetoLimpieza.haSidoLimpiado)
            {
                StartCoroutine(LimpiarObjeto(objetoActual, objetoLimpieza));
            }
        }
    }

    private IEnumerator LimpiarObjeto(GameObject objeto, ObjetoLimpieza objetoLimpieza)
    {
        limpiando = true;
        objeto.tag = "Limpiando";
        objeto.transform.position = UbicacionObjeto.position;
        objeto.transform.rotation = UbicacionObjeto.rotation;
        objeto.transform.SetParent(UbicacionObjeto);

        float tiempoLimpieza = 10f; // Tiempo de limpieza en segundos
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoLimpieza)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / tiempoLimpieza;
            barraProgreso.ActualizarProgreso(progreso);
            yield return null;
        }

        LimpiarCompletado(objetoLimpieza);
        limpiando = false;
    }

    private void LimpiarCompletado(ObjetoLimpieza objetoLimpieza)
    {
        // Aquí puedes añadir la lógica que se ejecuta cuando el objeto ha sido limpiado
        Debug.Log("Objeto limpiado: " + objetoActual.name);
        objetoActual.tag = "Objeto";
        objetoLimpieza.haSidoLimpiado = true; // Actualizar el booleano a true
        barraProgreso.ActualizarProgreso(0); // Resetear la barra de progreso
    }
}
