using UnityEngine;

public class BuscadorDeObjetos : MonoBehaviour
{
    private float intervalo = 0.5f; // Intervalo en segundos para buscar objetos
    private float tiempoTranscurrido = 0f;

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime; // Aumentar el tiempo transcurrido

        // Verificar si ha pasado el intervalo de tiempo
        if (tiempoTranscurrido >= intervalo)
        {
            tiempoTranscurrido = 0f; // Reiniciar el tiempo transcurrido
            BorrarObjetosHijos();
        }
    }

    private void BorrarObjetosHijos()
    {
        // Encontrar todos los objetos hijos del objeto que tiene este script
        Transform[] objetosHijos = GetComponentsInChildren<Transform>(true);

        // Iterar sobre los objetos hijos (comenzando desde el segundo, ya que el primero es el objeto mismo)
        for (int i = 1; i < objetosHijos.Length; i++)
        {
            // Destruir el objeto hijo
            Destroy(objetosHijos[i].gameObject);
        }
    }
}
