using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public bool mudarPosicao = false;
    public Vector3 playerPosition;
    public Vector3 playerRotation;
    public int delayCena;
    public int cena;
    public GameObject FadeScreen;
    public AudioSource audio;
    bool mouseOnObject;
    private GameObject Jogador;
    //private GameObject Enable;
    //public string enableName;    
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

    private IEnumerator WaitForSceneLoad()
    {
      yield return new WaitForSeconds(delayCena);
      SceneManager.LoadScene(cena);
      //Enable = GameObject.FindWithTag("Player1");
      //Enable.SetActive(true);

    }

}

/*
  if (mudarPosicao)
        {
            yield return new WaitForSeconds(delayCena);
            SceneManager.LoadScene(cena);
            Jogador = GameObject.FindGameObjectWithTag("Player");
            Jogador.transform.position = playerPosition;
            Jogador.transform.rotation = Quaternion.Euler(playerRotation);

        }
        if (!mudarPosicao)
        {
            yield return new WaitForSeconds(delayCena);
            SceneManager.LoadScene(cena);
        }
*/