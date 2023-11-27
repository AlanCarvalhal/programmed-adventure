using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public GameObject mission;
    public AudioSource gameAudio;
    public int delayAudio;
    public GameObject FadeScreen;
    public GameObject inactive;
    public GameObject active;
    public int delay;
    public bool cutscene;
    bool mouseOnObject;
    private GameObject Player;
    //public static Quaternion rotation;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        if (cutscene)
        {
            mission.SetActive(false);
            FadeScreen.SetActive(true);
            FadeScreen.GetComponent<Animation>().Play("FadeAnim");
            gameAudio.PlayDelayed(3);
            StartCoroutine(WaitForCutscene());

        }
    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        if (mouseOnObject == true && Vector3.Distance(transform.position, Player.transform.position) < distancia && Input.GetKeyDown(KeyCode.F) && !cutscene)
        {                
           gameAudio.PlayDelayed(delayAudio);
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

    private IEnumerator WaitForCutscene()
    {
        yield return new WaitForSeconds(delay);
        if (inactive != null) inactive.SetActive(false);
        if (active != null) active.SetActive(true);        
        FadeScreen.SetActive(false);        
        mission.SetActive(true);
    }
}
