using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.Reflection;
using UnityEngine;

public class SolveChallenge : MonoBehaviour
{
    bool mouseOnObject;
    private GameObject Jogador;
    public GameObject mission;
    public GameObject inputField;
    private string message;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, Jogador.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            loadChallenge();
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

    public void SetMessage(string message)
    {
        this.message = message;
    }

    public void loadChallenge()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Jogador.GetComponent<FirstPersonController>().enabled = false;
        mission.SetActive(true);
    }

    public void sendAnswer()
    {
        CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
        Debug.Log(message);
    }
}