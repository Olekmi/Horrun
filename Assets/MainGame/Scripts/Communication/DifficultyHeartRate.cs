﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHeartRate : MonoBehaviour
{
    public GameObject heartRateStatsObject;
    public float diffcultyCheckRate = 15f;
    private HeartRateStats heartRateStats;
    private int difficulty = 3; // 5 levels of difficulty
    // Start is called before the first frame update
    void Start()
    {
        heartRateStats = heartRateStatsObject.GetComponent<HeartRateStats>();
        InvokeRepeating("difficultyCheck", 1, diffcultyCheckRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void difficultyCheck()
    {
        // make it more difficult
        if (heartRateStats.changeInBpm < 0 && difficulty < 5)
        {
            ++difficulty;
            changeDifficulty();
        }
        // make it easier
        else if (heartRateStats.changeInBpm > 0 && difficulty > 1)
        {
            --difficulty;
            changeDifficulty();
        }
    }

    private void changeDifficulty()
    {
        switch (difficulty)
        {
            case 1:
                Debug.Log("dif 1");
                DifficultyHandler.Instance.SetSpeed(30, 5);
                DifficultyHandler.Instance.SetSpawnRate(1, 3, 0, 1, 5, .5f, 5);
                StartCoroutine(DifficultyHandler.Instance.SkyBoxChanger(0f, 5));
                break;
            case 2:
                Debug.Log("dif 2");
                DifficultyHandler.Instance.SetSpeed(50, 5);
                DifficultyHandler.Instance.SetSpawnRate(2, 4, 1, 3, 4, .3f, 5);
                StartCoroutine(DifficultyHandler.Instance.SkyBoxChanger(0f, 5));
                break;
            case 3:
                Debug.Log("dif 3");
                DifficultyHandler.Instance.SetSpeed(80, 5);
                DifficultyHandler.Instance.SetSpawnRate(3, 5, 1, 3, 3, .2f, 5);
                StartCoroutine(DifficultyHandler.Instance.SkyBoxChanger(.5f, 5));
                break;
            case 4:
                Debug.Log("dif 4");
                DifficultyHandler.Instance.SetSpeed(100, 5);
                DifficultyHandler.Instance.SetSpawnRate(3, 5, 2, 4, 2, .2f, 3);
                StartCoroutine(DifficultyHandler.Instance.SkyBoxChanger(1f, 5));
                break;
            case 5:
                Debug.Log("dif 5");
                DifficultyHandler.Instance.SetSpeed(120, 5);
                DifficultyHandler.Instance.SetSpawnRate(4, 7, 2, 4, 2, .2f, 2);
                StartCoroutine(DifficultyHandler.Instance.SkyBoxChanger(1f, 5));
                break;
            default:
                break;
        }
    }
}