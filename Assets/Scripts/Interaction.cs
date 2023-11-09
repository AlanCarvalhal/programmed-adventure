using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    bool mouseOnObject;
    private Camera camera;
    //public GameObject programingScreen;
    public GameObject auxActive;
    public GameObject auxInactive;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;  

    void Start()
    {
       camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, camera.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            //programingScreen.SetActive(false);
            auxInactive.SetActive(false);
            auxActive.SetActive(true);
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
}
