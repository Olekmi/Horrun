using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceDifficulty : MonoBehaviour
{
    private int difficulty = 3;
    public float diffCheckTime = 15f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("difficultyCheck", 0, diffCheckTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void difficultyCheck()
    {
        // if health is >3 then increase difficulty gradually
        // if health is <=3 then maximalize difficulty.
        switch (PlayerStats.Instance.Health)
        {
            case float n when (n > 3):
                ++difficulty;
                break;
            case float n when (3 <= n && n > 2):
                if (difficulty > 4) difficulty = 4;
                break;
            case float n when (2 <= n && n > 1):
                if (difficulty > 3) difficulty = 3;
                break;
            case float n when (n <= 1 && n > 0):
                if (difficulty > 2) difficulty = 2;
                break;
            default:
                break;
        }
        // update difficulty
        changeDifficulty();
    }

    private void changeDifficulty()
    {
        switch (difficulty)
        {
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
