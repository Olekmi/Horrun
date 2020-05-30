using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler: MonoBehaviour
{
    // difficulty constants
    private float scrollAnimSeconds = 3f;
    // current values
    public float scrollSpeed = 50f;
    // new values
    private float oldScrollSpeed = 50f;
    private float newScrollSpeed = 50f;
    // interpolation times
    private float scrollAnimationTime = 1.1f;

    // associated objects
    public GameObject spawner = null;
    private ObstacleSpawner spawnerScript = null;
    public GameObject potionSpawner = null;
    private PotionSpawner pSpawnerScript = null;
    
    // make this a singleton
    #region Singleton
    private static DifficultyHandler instance;
    public static DifficultyHandler Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<DifficultyHandler>();
            return instance;
        }
    }
    #endregion

    public void Start()
    {
        spawnerScript = spawner.GetComponent<ObstacleSpawner>();
        pSpawnerScript = potionSpawner.GetComponent<PotionSpawner>();

        spawnerScript.minObstacle = 3;
        spawnerScript.maxObstacle = 5;
        spawnerScript.InvokeRepeating("Spawn",0,5f);

        pSpawnerScript.chance = .1f;
        pSpawnerScript.maxHealth = 3f;
        pSpawnerScript.InvokeRepeating("Spawn", 2.5f, 5f);
    }

    public void setSpeed(float newScrollSpeed, float scrollTransitionSeconds)
    {
        oldScrollSpeed = scrollSpeed;
        this.newScrollSpeed = newScrollSpeed;
        scrollAnimationTime = 0;
        scrollAnimSeconds = scrollTransitionSeconds;
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
                scrollSpeed = Mathf.Lerp(oldScrollSpeed, newScrollSpeed, scrollAnimationTime);
            }
        }
    }
}
