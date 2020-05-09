using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler: MonoBehaviour
{
    // difficulty constants
    private const float scrollSpeedEasy = 50f;
    private const float scrollSpeedHard = 80f;
    private const float scrollAnimSeconds = 3f;
    // current values
    public float scrollSpeed = 50f;
    // new values
    private float newScrollSpeed = 50f;
    // interpolation times
    private float scrollAnimationTime = 0;

    // associated objects
    public GameObject spawner = null;
    private ObstacleSpawner spawnerScript = null;
    

    public void Start()
    {
        spawnerScript = spawner.GetComponent<ObstacleSpawner>();
        spawnerScript.min = 3;
        spawnerScript.max = 5;
        spawnerScript.InvokeRepeating("Spawn",0,5f);
    }

    public void setHard(bool hardIsOn)
    {
        if (hardIsOn)
        {
            newScrollSpeed = scrollSpeedHard;
        }
        else
        {
            newScrollSpeed = scrollSpeedEasy;
        }
    }

    public void Update()
    {
        // scroll speed update
        if (scrollSpeed != newScrollSpeed)
        {
            if (scrollAnimationTime <= 1)
            {
                // time update
                if (scrollSpeed < newScrollSpeed) scrollAnimationTime = Mathf.Max(1f, scrollAnimationTime + Time.deltaTime / scrollAnimSeconds);
                else scrollAnimationTime = Mathf.Min(0f, scrollAnimationTime - Time.deltaTime / scrollAnimSeconds);
                // value update
                scrollSpeed = Mathf.Lerp(scrollSpeedEasy, scrollSpeedHard, scrollAnimationTime);
            }
        }
    }
}
