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
    private float previousInvokeRate = 0f;

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

        setSpawnRate(3, 5, 3, 5, 3f, .1f, 5);
    }

    public void setSpeed(float newScrollSpeed, float scrollTransitionSeconds)
    {
        oldScrollSpeed = scrollSpeed;
        this.newScrollSpeed = newScrollSpeed;
        scrollAnimationTime = 0;
        scrollAnimSeconds = scrollTransitionSeconds;
    }

    public void setSpawnRate(int minObstacle, int maxObstacle, int minEnemy, int maxEnemy, float maxHealth, float chance, float sec)
    {
        spawnerScript.CancelInvoke();
        pSpawnerScript.CancelInvoke();

        spawnerScript.minObstacle = minObstacle;
        spawnerScript.maxObstacle = maxObstacle;
        spawnerScript.minEnemy = minEnemy;
        spawnerScript.maxEnemy = maxEnemy;
        pSpawnerScript.maxHealth = maxHealth;
        pSpawnerScript.chance = chance;

        spawnerScript.InvokeRepeating("Spawn", previousInvokeRate, sec);
        pSpawnerScript.InvokeRepeating("Spawn", previousInvokeRate + (sec/2), sec);

        previousInvokeRate = sec;
    }

    public void Update()
    {
        // scroll speed update
        if (scrollSpeed != newScrollSpeed)
        {
            if (scrollAnimationTime <= 1)
            {
                // time update
                scrollAnimationTime = Mathf.Max(1f, scrollAnimationTime + Time.deltaTime / scrollAnimSeconds);
                // value update
                scrollSpeed = Mathf.Lerp(oldScrollSpeed, newScrollSpeed, scrollAnimationTime);
            }
        }
    }
}
