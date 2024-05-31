using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MesaEntrega : MonoBehaviour
{
    public TextMeshProUGUI puntuacionText; // Referencia al objeto Text(TMP) en el Canvas
    public TextMeshProUGUI puntuacionFinal; // Referencia al objeto Text(TMP) en el Canvas
    public TextMeshProUGUI recetasSolicitadasText; // Referencia al objeto Text(TMP) para mostrar las recetas solicitadas
    public int puntos = 0; // Variable para almacenar los puntos del jugador
    private float intervaloReceta = 20f; // Intervalo en segundos para cambiar la receta
    private float tiempoTranscurridoReceta = 0f;

    // Lista de recetas solicitadas
    private List<List<string>> recetasSolicitadas = new List<List<string>>();

    // Lista de recetas disponibles
    private List<List<string>> recetas = new List<List<string>>();

    // Variables para almacenar los objetos entregados y la receta seleccionada actualmente
    private List<string> entregados = new List<string>();
    private List<string> recetaSeleccionada;

    void Start()
    {
        // Definir recetas disponibles
        recetas.Add(new List<string> { "Caja", "Procesador" });
        recetas.Add(new List<string> { "Caja", "ram" });
        recetas.Add(new List<string> { "Caja", "Procesador", "ram" });

        // Iniciar primera receta
        SeleccionarRecetaAleatoria();

        // Llamar a Recursiva cada segundo
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
        // Verificar si la lista de recetas solicitadas ya tiene 4 recetas
        if (recetasSolicitadas.Count < 4)
        {
            // Añadir una receta aleatoria a la lista
            recetaSeleccionada = recetas[Random.Range(0, recetas.Count)];
            recetasSolicitadas.Add(recetaSeleccionada);
            ActualizarRecetasSolicitadasText();
        }
    }

    private void ActualizarRecetasSolicitadasText()
    {
        string recetasText = "Pedidos entrantes:\n";
        foreach (List<string> receta in recetasSolicitadas)
        {
            recetasText += "- " + string.Join(", ", receta) + "\n";
        }
        recetasSolicitadasText.text = recetasText;
    }

    private void Recursiva()
    {
        // Actualizar la lista de objetos entregados
        ActualizarEntregados();

        // Intentar entregar la receta
        EntregarReceta(entregados, recetaSeleccionada);
    }

    private void ActualizarEntregados()
    {
        entregados.Clear();
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

    private void EntregarReceta(List<string> entregados, List<string> recetaSeleccionada)
    {
        // Iterar sobre todas las recetas solicitadas
        foreach (List<string> receta in recetasSolicitadas)
        {
            // Verificar si la receta entregada coincide con alguna receta solicitada
            if (CombinacionCoincide(receta, entregados))
            {
                // Si la receta coincide, sumar puntos
                puntos += 50 * entregados.Count; // Por ejemplo, 5 puntos por cada objeto entregado
                ActualizarPuntuacion();

                // Eliminar los objetos entregados
                foreach (Transform hijo in transform)
                {
                    Destroy(hijo.gameObject);
                }

                // Remover la receta entregada de la lista de recetas solicitadas
                recetasSolicitadas.Remove(receta);
                // Actualizar el texto de las recetas solicitadas en la pantalla
                ActualizarRecetasSolicitadasText();
                break;
            }
        }
    }

    private void ActualizarPuntuacion()
    {
        puntuacionText.text = "Puntos: " + puntos;
        puntuacionFinal.text = " "+puntos;
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
