using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject blackScreen;
    public FirstPersonController fpc;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuUI.activeSelf)
            {
                optionsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
            else if (GamePaused)
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
        fpc.cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        blackScreen.SetActive(true);
    }

    void Pause()
    {
        fpc.cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        blackScreen.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
