using UnityEngine;

public class EsconderMenu : MonoBehaviour
{
    public GameObject menuInicio;

    // Este m�todo har� que el objeto menuInicio desaparezca
    public void HideMenuInicio()
    {
        if (menuInicio != null)
        {
            menuInicio.SetActive(false);
        }
    }
}
