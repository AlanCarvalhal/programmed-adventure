using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Interaction : MonoBehaviour
{
    bool mouseOnObject;    
    public GameObject mission;    
    public GameObject auxActive;
    public GameObject auxActive_lines;
    public GameObject auxInactive;    
    public bool code;
    public string[] missionLines;
    public TextMeshProUGUI textMission;
    public bool changeMission = true;    
    public bool note = false;
    public bool finish = false;

    private Animator m_Animator;
    private Camera playerCamera;
    private bool aux = true;
    [Range(0.1f, 20.0f)] public float distancia = 7.5f;  

    void Start()
    {
        playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
        m_Animator = playerCamera.GetComponent<Animator>();
        if (mouseOnObject == true && Vector3.Distance(transform.position, playerCamera.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            if (code)
            {
                if (mission != null) mission.SetActive(false);
                if (m_Animator != null) m_Animator.Play("Notebook");
                StartCoroutine(WaitAnimCode());
            }
            if (!code)
            {
                if (finish && mission != null) mission.SetActive(false);
                if (auxInactive != null) auxInactive.SetActive(false);
                if (auxActive != null) auxActive.SetActive(true);
                if (auxActive_lines != null && aux) auxActive_lines.SetActive(true);
                if (note) {
                    FirstPersonController.cameraCanMoveStatic = false;
                    textMission.text = missionLines[0];
                }
                aux = false;
            }
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
    
    private IEnumerator WaitAnimCode()
    {
        yield return new WaitForSeconds(2);
        if (changeMission) textMission.text = missionLines[0];
        if (auxInactive != null) auxInactive.SetActive(false);
        if (auxActive != null) auxActive.SetActive(true);
        gameObject.GetComponent<Interaction>().enabled = false;
        FirstPersonController.cameraCanMoveStatic = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
}
