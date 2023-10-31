using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool mudarPosicao;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public int delayCena;
    public int cena;
    public GameObject FadeScreen;
    public AudioSource audio;
    bool mouseOnObject;
    private GameObject Jogador;    
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, Jogador.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
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

    private IEnumerator WaitForSceneLoad() {
    yield return new WaitForSeconds(delayCena);
    SceneManager.LoadScene(cena);
    
}
}