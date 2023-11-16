using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
    public GameObject mission;
    public GameObject change;
    public GameObject active;
    public GameObject inactive;
    public GameObject inactiveLines;
    public GameObject activeLines;
    public GameObject erroScreen;
    private GameObject Player;

    //input

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //Player.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FirstPersonController.cameraCanMoveStatic = false;
    }

    //Close(); certo
    //StartCoroutine(WaitForSceneLoad()); erro

    // inicio analise de codigos

    

    // fim analise de codigos

    public void Close()
    {
        if (inactive != null) inactive.SetActive(false);
        if (change != null) change.SetActive(true);
        if (mission != null) mission.SetActive(true);
        gameObject.SetActive(false);
        if (inactiveLines != null) inactiveLines.SetActive(false);
        if (activeLines != null) activeLines.SetActive(true);
        if (active != null) active.SetActive(true);
        Cursor.visible = false;
        FirstPersonController.cameraCanMoveStatic = true;
        //Player.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator WaitForSceneLoad()
    {
        erroScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        erroScreen.SetActive(false);
    }
}
