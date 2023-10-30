using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    bool mouseOnObject;
    private GameObject Jogador;
    public int cena;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, Jogador.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(cena);
        }
    }
    private void OnMouseEnter()
    {
        mouseOnObject = true;
    }

    private void OnMouseExit()
    {
        mouseOnObject = false;
    }

    public void MudaCena()
    {
        SceneManager.LoadScene(cena);
    }
}