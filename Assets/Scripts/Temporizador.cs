using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI Tiempo;
    public float cuenta = 0;
    private MesaEntrega mesaEntrega;
    public GameObject canvasFinal;
    public TextMeshProUGUI mensajePuntuacion;
    public string nombreEscena; // Esta variable será configurable desde el Inspector
    float cuentaInicial;

    void Start()
    {
        cuentaInicial = cuenta;
        // Buscar el objeto que tiene el script MesaEntrega y obtener la referencia
        mesaEntrega = FindObjectOfType<MesaEntrega>();
        if (mesaEntrega == null)
        {
            Debug.LogError("No se encontró un objeto con el script MesaEntrega.");
        }

        // Asegurarse de que el canvas final esté desactivado al inicio
        if (canvasFinal != null)
        {
            canvasFinal.SetActive(false);
        }
    }

    void Update()
    {
        cuenta -= Time.deltaTime;

        Tiempo.text = cuenta.ToString("f0"); // f0 es para que salga solo la parte entera

        // Si el tiempo llega a 0, mostrar el canvas final
        if (cuenta <= 0)
        {
            if (mesaEntrega != null && mesaEntrega.puntos >= 400)
            {
                ControladorNiveles.instancia.AumentarNiveles();
            }
            cuenta = 0;
            Time.timeScale = 0;
            canvasFinal.SetActive(true);
        }
    }

    // Método para manejar el botón de volver al menú
    public void VolverAlMenu()
    {
        Time.timeScale = 1;
        cuenta = cuentaInicial;
        SceneManager.LoadScene("SelectorNiveles");
    }

    // Método para manejar el botón de volver a jugar
    public void VolverAJugar()
    {
        Time.timeScale = 1;
        cuenta = cuentaInicial;
        // Usar el nombre de la escena que se ha configurado en el Inspector
        SceneManager.LoadScene(nombreEscena);
    }
}