using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
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
        Time.timeScale = 1f;
        isGamePaused = false;
        Debug.Log("Çalıştı");
    }

    void Pause() 
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Debug.Log("Çalıştı");
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Çalıştı");

    }
}
