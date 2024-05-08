using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{

    public TextMeshProUGUI Tiempo;

    public float cuenta = 0;

    void Start()
    {
        // Llama a la función 'NuevoPedido' cada 2 segundos, después de 0 segundos de retraso.
        InvokeRepeating("NuevoPedido", 0f, 2f);
    }



    void Update()
    {
        cuenta -=Time.deltaTime;

        Tiempo.text = "" + cuenta.ToString("f0"); //f0 es para que salga solo una decima


        if(cuenta <= 0)
        {
            //Para el juego
            cuenta = 0;
            Time.timeScale = 0;
        }
        
    }
    // Esta función se llamará cada 2 segundos
    void NuevoPedido()
    {
        Debug.Log("Nuevo pedido");
    }
}
