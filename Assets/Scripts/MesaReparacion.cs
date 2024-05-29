using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MesaReparacion : MonoBehaviour
{
    public Transform UbicacionObjeto; // La ubicación donde se coloca el objeto para limpiarse
    public BarraProgreso barraProgreso; // Referencia a la barra de progreso
    private GameObject objetoActual;
    private bool reparando = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!reparando && collision.gameObject.CompareTag("Objeto"))
        {
            objetoActual = collision.gameObject;
            ObjetoReparacion ObjetoReparacion = objetoActual.GetComponent<ObjetoReparacion>();

            if (ObjetoReparacion != null && !ObjetoReparacion.haSidoReparado)
            {
                StartCoroutine(RepararObjeto(objetoActual, ObjetoReparacion));
            }
        }
    }

    private IEnumerator RepararObjeto(GameObject objeto, ObjetoReparacion ObjetoReparacion)
    {
        reparando = true;
        objeto.tag = "Reparado";
        objeto.transform.position = UbicacionObjeto.position;
        objeto.transform.rotation = UbicacionObjeto.rotation;
        objeto.transform.SetParent(UbicacionObjeto);

        float tiempoReparacion = 10f; // Tiempo de limpieza en segundos
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoReparacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / tiempoReparacion;
            barraProgreso.ActualizarProgreso(progreso);
            yield return null;
        }

        RepararCompletado(ObjetoReparacion);
        reparando = false;
    }

    private void RepararCompletado(ObjetoReparacion ObjetoReparacion)
    {
        objetoActual.tag = "Objeto";
        ObjetoReparacion.haSidoReparado = true;
        barraProgreso.ActualizarProgreso(0);
    }
}
