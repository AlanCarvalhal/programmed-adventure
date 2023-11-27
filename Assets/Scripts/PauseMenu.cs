using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject controlsMenuUI;
    public GameObject blackScreen;
    private GameObject codes;

    void Update()
    {
        codes = GameObject.FindWithTag("code");      
        if (Input.GetKeyDown(KeyCode.Escape) && codes == null)
        {
            if (optionsMenuUI.activeSelf)
            {
                optionsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
            else if (controlsMenuUI.activeSelf)
            {
                controlsMenuUI.SetActive(false);
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
        FirstPersonController.cameraCanMoveStatic = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        //blackScreen.SetActive(true);
    }

    void Pause()
    {
        FirstPersonController.cameraCanMoveStatic = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
       // blackScreen.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
