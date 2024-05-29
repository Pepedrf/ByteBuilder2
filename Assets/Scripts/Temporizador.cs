using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{

    public TextMeshProUGUI Tiempo;

    public float cuenta = 0;

    void Update()
    {
        cuenta -=Time.deltaTime;

        Tiempo.text = "" + cuenta.ToString("f0"); //f0 es para que salga solo una decima

        //Si el tiempo llega a 0 se desbloquea el proximo nivel
        if(cuenta <= 0)
        {
            ControladorNiveles.instancia.AumentarNiveles();
            SceneManager.LoadScene("SelectorNiveles");
            cuenta = 0;
            Time.timeScale = 0;
        } 
    }
}
