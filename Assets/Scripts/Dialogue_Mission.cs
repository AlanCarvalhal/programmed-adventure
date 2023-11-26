using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dialogue_Mission : MonoBehaviour
{
    public GameObject missionBox;

    private void OnEnable()
    {
        missionBox.SetActive(false);
    }

    private void OnDisable()
    {
        missionBox.SetActive(true);
    }
}
