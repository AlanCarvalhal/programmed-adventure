using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public bool changePlayer = false;    
    public GameObject playerAfter;   
    public int delayCena;
    public int cena;
    public GameObject FadeScreen;
    public AudioSource audio;       
    bool mouseOnObject;
    private GameObject Player;
    public GameObject mission;
    public string[] missionLines;
    public TextMeshProUGUI textMission;
    private bool dontRepeat = false;
    public bool changeMission = false;
    public bool finish = false;

    //public static Quaternion rotation;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;   
    
    void Start()
    {
      Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        if (mouseOnObject == true && Vector3.Distance(transform.position, Player.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(WaitForSceneLoad());
            FadeScreen.SetActive(true);
            if (mission != null) mission.SetActive(false);
            if (changeMission && !dontRepeat && textMission != null)
            {
                textMission.text = missionLines[0];
            }
            if (changeMission && MovePlayer.bed && finish && textMission != null)
            {
                textMission.text = missionLines[0];
            }
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
        if (changePlayer)
        {
            yield return new WaitForSeconds(delayCena);            
            Player.SetActive(false);
            if (playerAfter != null) playerAfter.SetActive(true);
            if (mission != null) mission.SetActive(true);
            FadeScreen.SetActive(false);
            dontRepeat = true;
        }
        else if(!changePlayer)
        {
            yield return new WaitForSeconds(delayCena);
            SceneManager.LoadScene(cena);            
        }
    }    
}
