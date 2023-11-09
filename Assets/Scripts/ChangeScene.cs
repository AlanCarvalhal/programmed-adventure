using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public bool changeTutorial;
    public bool changeFarm;
    public bool changeWorkshop;
    public bool changeHouse;    
    public static bool house;   
    public static bool tutorial;
    public static bool farm;
    public static bool workshop;
    public int delayCena;
    public int cena;
    public GameObject FadeScreen;
    public AudioSource audio;       
    bool mouseOnObject;
    private GameObject Player;

//public static Quaternion rotation;
[Range(0.1f, 10.0f)] private float distancia = 7.5f;   

    void Start()
    {
      Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, Player.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            house = changeHouse;
            tutorial = changeTutorial;
            farm = changeFarm;
            workshop = changeWorkshop;

            StartCoroutine(WaitForSceneLoad());
            FadeScreen.GetComponent<Animation>().Play("FadeAnim");
            audio.PlayDelayed(3);
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

    private IEnumerator WaitForSceneLoad()
    {        
        yield return new WaitForSeconds(delayCena);
        SceneManager.LoadScene(cena);
    }    
}
