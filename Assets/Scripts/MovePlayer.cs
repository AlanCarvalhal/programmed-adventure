using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public GameObject playerTutorial;
    public GameObject playerHouse;
    public GameObject playerCityHouse;
    public GameObject playerFarm;
    public GameObject playerWorkshop;
    public static bool bridge = false;
    public static bool office_door = false;
    public static bool library_door = false;
    public static bool truck = false;
    public static bool bed = false;
    public GameObject bridge_Object;
    public GameObject office_door_Object;
    public GameObject library_door_Object;
    public GameObject truck_Object;
    public GameObject bed_Object;

    void Awake()
    {
        if (ChangeScene.tutorial)
        {
            playerTutorial.SetActive(false);
            playerHouse.SetActive(true);
        }
        if (ChangeScene.farm)
        {
            playerCityHouse.SetActive(false);
            playerFarm.SetActive(true);
            playerWorkshop.SetActive(false);
         }
        if (ChangeScene.house)
        {
            playerCityHouse.SetActive(true);
            playerFarm.SetActive(false);
            playerWorkshop.SetActive(false);
        }       
        if (ChangeScene.workshop)
        {
            playerCityHouse.SetActive(false);
            playerFarm.SetActive(false);
            playerWorkshop.SetActive(true);
        }
    }

    private void Start()
    {
        if (bridge == false) if (bridge_Object != null) bridge_Object.SetActive(true);
        if (office_door == false) if (office_door_Object != null) office_door_Object.SetActive(true);
        if (library_door == false) if (library_door_Object != null) library_door_Object.SetActive(true);
        if (truck == false) if (truck_Object != null) truck_Object.SetActive(true);
        if (bed == false) if (bed_Object != null) bed_Object.SetActive(true);
    }
}
