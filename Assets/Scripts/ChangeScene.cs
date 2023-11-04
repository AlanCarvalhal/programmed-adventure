using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public static bool changePosition;
    public static Vector3 position;
    public bool changePositionValue;
    public bool savePosition;
    public int delayCena;
    public int cena;
    public GameObject FadeScreen;
    public AudioSource audio;       
    bool mouseOnObject;
    private GameObject Player;

//public static Quaternion rotation;
[Range(0.1f, 10.0f)] private float distancia = 7.5f;

    void Awake()
    {
        changePosition = changePositionValue;
    }

    void Start()
    {
      Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (mouseOnObject == true && Vector3.Distance(transform.position, Player.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            if (savePosition)
            {
              position = Player.transform.position;
            }
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
