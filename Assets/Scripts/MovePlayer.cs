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
}
