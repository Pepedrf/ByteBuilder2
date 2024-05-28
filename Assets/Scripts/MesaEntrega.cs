using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MesaEntrega : MonoBehaviour
{
    public TextMeshProUGUI puntuacionText; // Referencia al objeto Text(TMP) en el Canvas
    private int puntos = 0; // Variable para almacenar los puntos del jugador
    private float intervaloReceta = 10f; // Intervalo en segundos para cambiar la receta
    private float tiempoTranscurridoReceta = 5f;

    // Lista de recetas solicitadas
    private List<List<string>> recetasSolicitadas = new List<List<string>>();

    // Lista de recetas disponibles
    private List<List<string>> recetas = new List<List<string>>();

    // Variables para almacenar los objetos entregados y la receta seleccionada actualmente
    private List<string> entregados;
    private List<string> recetaSeleccionada;

    void Start()
    {
        // Definir recetas disponibles
        recetas.Add(new List<string> { "Caja", "Procesador" });
        recetas.Add(new List<string> { "Caja", "Grafica" });
        // Agrega más recetas según sea necesario

        // Iniciar primera receta
        SeleccionarRecetaAleatoria();

        // Llamar a SeleccionarRecetaAleatoria cada segundo
        InvokeRepeating("Recursiva", 1f, 1f);
    }

    void Update()
    {
        // Aumentar el tiempo transcurrido para la selección de recetas
        tiempoTranscurridoReceta += Time.deltaTime;

        // Verificar si ha pasado el intervalo para cambiar la receta
        if (tiempoTranscurridoReceta >= intervaloReceta)
        {
            tiempoTranscurridoReceta = 0f; // Reiniciar el tiempo transcurrido
            SeleccionarRecetaAleatoria();
        }
    }

    private void SeleccionarRecetaAleatoria()
    {
        // Seleccionar una receta aleatoria
        recetaSeleccionada = recetas[Random.Range(0, recetas.Count)];

        // Añadir la receta seleccionada a la lista de recetas solicitadas
        recetasSolicitadas.Add(recetaSeleccionada);

        // Mostrar la receta seleccionada en la consola
        Debug.Log("Receta seleccionada: " + string.Join(", ", recetaSeleccionada));

        // Verificar si la receta coincide con los objetos entregados
        entregados = new List<string>();
        Transform[] objetosHijos = GetComponentsInChildren<Transform>(true);

        for (int i = 1; i < objetosHijos.Length; i++)
        {
            IdentificadorObjeto identificador = objetosHijos[i].GetComponent<IdentificadorObjeto>();
            if (identificador != null)
            {
                entregados.Add(identificador.tipoObjeto);
            }
        }
    }

    private void Recursiva()
    {
        EntregarReceta(entregados, recetaSeleccionada);
    }

    private void EntregarReceta(List<string> entregados, List<string> recetaSeleccionada)
    {

        // Iterar sobre todas las recetas solicitadas
        foreach (List<string> receta in recetasSolicitadas)
        {
            // Verificar si la receta entregada coincide con alguna receta solicitada
            if (CombinacionCoincide(receta, entregados))
            {
                // Si la receta coincide, sumar puntos
                puntos += 5 * entregados.Count; // Por ejemplo, 5 puntos por cada objeto entregado
                ActualizarPuntuacion();

                // Eliminar los objetos entregados
                foreach (Transform hijo in transform)
                {
                    Destroy(hijo.gameObject);
                }

                // Remover la receta entregada de la lista de recetas solicitadas
                recetasSolicitadas.Remove(receta);
                break;
            }
        }
    }

    private void ActualizarPuntuacion()
    {
        puntuacionText.text = "Puntos: " + puntos;
    }

    private bool CombinacionCoincide(List<string> combinacion, List<string> entregados)
    {
        if (combinacion.Count != entregados.Count)
        {
            return false;
        }

        foreach (string objeto in combinacion)
        {
            if (!entregados.Contains(objeto))
            {
                return false;
            }
        }

        return true;
    }
}
