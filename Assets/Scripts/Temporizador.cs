using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{

    public TextMeshProUGUI Tiempo;

    public float cuenta = 0;

    // Lista para almacenar los prefabs
    public GameObject[] prefabs;

    void Start()
    {
        // Encontrar todos los objetos con la etiqueta "objeto"
        GameObject[] objetosConEtiqueta = GameObject.FindGameObjectsWithTag("Objeto");

        // Crear un array de objetos para almacenar las instancias
        GameObject[] arrayDeObjetos = new GameObject[objetosConEtiqueta.Length];

        // Copiar las instancias al array
        for (int i = 0; i < objetosConEtiqueta.Length; i++)
        {
            arrayDeObjetos[i] = objetosConEtiqueta[i];
        }

        // Imprimir los nombres de los objetos en el array
        foreach (GameObject objeto in arrayDeObjetos)
        {
            Debug.Log("Nombre del objeto: " + objeto.name);
        }
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
