using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pausa el tiempo
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo vuelve a ser normal al salir al menú principal
        SceneManager.LoadScene("SelectorNiveles");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
