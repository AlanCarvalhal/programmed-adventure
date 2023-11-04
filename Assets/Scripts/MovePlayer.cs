using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        if(ChangeScene.changePosition)
        player.transform.position = ChangeScene.position;
    }
}
