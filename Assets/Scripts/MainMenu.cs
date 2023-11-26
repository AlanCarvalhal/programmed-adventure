using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Jogar()
    {
      SceneManager.LoadScene(1);
    }

    public void Fechar()
    {
      Application.Quit();
    }

    public void Fim()
    {
        SceneManager.LoadScene(0);
    }
}
