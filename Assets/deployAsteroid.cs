using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroid : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 3f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector3(Random.Range(screenBounds.x * -15, screenBounds.x * 15), Random.Range(1, screenBounds.y), Camera.main.transform.position.z * 100);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}