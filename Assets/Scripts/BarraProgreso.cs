using UnityEngine;
using UnityEngine.UI;

public class BarraProgreso : MonoBehaviour
{
    public Image barraProgreso;

    public void ActualizarProgreso(float progreso)
    {
        barraProgreso.fillAmount = progreso;
    }
}
