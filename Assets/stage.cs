using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour
{

    public Transform spawnPoint;  

        
    public void Enter()
    {
        spawnPoint.gameObject.SetActive(false);
        FindAnyObjectByType<Player>().transform.position = spawnPoint.position;

        gameObject.SetActive(true);
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        Enter();
    }
}
