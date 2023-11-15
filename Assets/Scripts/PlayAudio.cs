using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audio;
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
            FadeScreen.GetComponent<Animation>().Play("FadeAnim");
            audio.PlayDelayed(3);
            StartCoroutine(WaitForCutscene());
        }
    }

    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        if (mouseOnObject == true && Vector3.Distance(transform.position, Player.transform.position) < distancia && Input.GetKeyDown(KeyCode.F) && !cutscene)
        {                
           audio.PlayDelayed(delayAudio);
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
        FadeScreen.SetActive(true);
    }
}
