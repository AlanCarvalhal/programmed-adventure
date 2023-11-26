using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{    
    public static bool bridge = false;
    public static bool office_door = false;
    public static bool library_door = false;
    public static bool truck = false;
    public static bool bed = false;
    public GameObject farmer;
    public GameObject bridge_Object;
    public GameObject library_door_Object;
    public GameObject truck_Object;
    public GameObject bed_Object;
   
    private void Update()
    {
        if (bridge == true && bridge_Object != null) bridge_Object.SetActive(true);
        if (bed == true && bed_Object != null) bed_Object.GetComponent<Interaction>().enabled = true;
        if (truck == true && truck_Object != null)
        {
            farmer.SetActive(true);
            truck_Object.SetActive(true);
        }
        if (library_door == true && library_door_Object != null) library_door_Object.SetActive(true);
    }
}
