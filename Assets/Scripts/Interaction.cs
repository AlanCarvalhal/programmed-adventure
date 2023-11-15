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
    public GameObject auxInactive;
    private bool bridge = true; //1
    private bool office_door = true; //2
    private bool library_door = true; //3
    private bool truck = true; //4
    private bool bed = true; //5
    public int unlock = 0;
    public bool code;
    public string[] missionLines;
    public TextMeshProUGUI textMission;

    private Animator m_Animator;
    private GameObject notebook;
    private Camera camera;
    [Range(0.1f, 10.0f)] private float distancia = 7.5f;  

    void Start()
    {
       camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    void Update()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
        m_Animator = camera.GetComponent<Animator>();
        if (mouseOnObject == true && Vector3.Distance(transform.position, camera.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
        {
            if (code)
            {
                if (mission != null) mission.SetActive(false);
                if (m_Animator != null) m_Animator.Play("Notebook");
                StartCoroutine(WaitAnimCode());
            }
            if (!code)
            {
                if (unlock == 0)
                {
                    if (auxInactive != null) auxInactive.SetActive(false);
                    if (auxActive != null) auxActive.SetActive(true);
                }
                else
                {
                    switch (unlock)
                    {
                        case 1:
                            MovePlayer.bridge = bridge;
                            break;
                        case 2:
                            MovePlayer.office_door = office_door;
                            break;
                        case 3:
                            MovePlayer.library_door = library_door;
                            break;
                        case 4:
                            MovePlayer.truck = truck;
                            break;
                        case 5:
                            MovePlayer.bed = bed;
                            break;
                        default:
                            break;
                    }
                }
                
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
        textMission.text = missionLines[0];
        if (auxInactive != null) auxInactive.SetActive(false);
        if (auxActive != null) auxActive.SetActive(true);       
        FirstPersonController.cameraCanMoveStatic = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.visible = true;
    }
}
