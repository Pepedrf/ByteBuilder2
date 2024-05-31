using UnityEngine;
using UnityEngine.UI;

public class BotonNivel : MonoBehaviour
{
    public Button boton;

    // M�todo para cambiar el color del bot�n seg�n la medalla obtenida
    public void CambiarColorBoton(string medalla)
    {
        Color color = Color.white; // Color por defecto

        switch (medalla)
        {
            case "Oro":
                color = Color.yellow;
                break;
            case "Plata":
                color = Color.gray;
                break;
            case "Bronce":
                color = new Color(0.804f, 0.498f, 0.196f); // Color bronce
                break;
        }

        // Cambiar el color del bot�n
        ColorBlock cb = boton.colors;
        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        boton.colors = cb;
    }
}
