using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<stage> stages;

    public int currentStageIndex = 0;

    public int score = 0;


    private void Start()
    {
        stages[currentStageIndex].Enter();
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StageClear() {
        Debug.Log("Stage Cleared, Score: " + score);

        stages[currentStageIndex].Exit();
        currentStageIndex++;
        stages[currentStageIndex].Enter();
    }

}

