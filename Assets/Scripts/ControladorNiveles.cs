using UnityEngine;
using UnityEngine.UI;

public class ControladorNiveles : MonoBehaviour
{
    public static ControladorNiveles instancia;
    public Button[] botonesNiveles;
    public int desbloquearNiveles;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    void Start()
    {
        if (botonesNiveles.Length > 0)
        {
            //Ponemos todos los botones con el interactuar desactivado
            for (int i = 0; i < botonesNiveles.Length; i++)
            {
                botonesNiveles[i].interactable=false;
            }

            //Activamos tantos botones como niveles hemos desbloqueado
            for (int i = 0; i < PlayerPrefs.GetInt("nivelesDesbloqueados",1); i++)
            {
                botonesNiveles[i].interactable = true;
            }
        }
    }

    public void AumentarNiveles()
    {
        if (desbloquearNiveles > PlayerPrefs.GetInt("nivelesDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("nivelesDesbloqueados", desbloquearNiveles);
        }
    }
}
