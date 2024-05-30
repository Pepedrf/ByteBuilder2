using UnityEngine;

public class EsconderMenu : MonoBehaviour
{
    public GameObject menuInicio;

    // Este método hará que el objeto menuInicio desaparezca
    public void HideMenuInicio()
    {
        if (menuInicio != null)
        {
            menuInicio.SetActive(false);
        }
    }
}
