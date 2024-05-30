using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI Tiempo;
    public float cuenta = 0;
    private MesaEntrega mesaEntrega; // Referencia al script MesaEntrega

    void Start()
    {
        // Buscar el objeto que tiene el script MesaEntrega y obtener la referencia
        mesaEntrega = FindObjectOfType<MesaEntrega>();
        if (mesaEntrega == null)
        {
            Debug.LogError("No se encontró un objeto con el script MesaEntrega.");
        }
    }

    void Update()
    {
        cuenta -= Time.deltaTime;

        Tiempo.text = "" + cuenta.ToString("f0"); // f0 es para que salga solo una décima

        // Si el tiempo llega a 0, verificar la puntuación
        if (cuenta <= 0)
        {
            if (mesaEntrega != null && mesaEntrega.puntos >= 550)
            {
                ControladorNiveles.instancia.AumentarNiveles();
            }
            SceneManager.LoadScene("SelectorNiveles");
            cuenta = 0;
            Time.timeScale = 0;
        }
    }
}
