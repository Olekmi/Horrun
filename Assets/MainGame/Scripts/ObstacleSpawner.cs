using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public const int maxCubes = 15;
    private uint[] positions = new uint[15];
    private uint tempPos;
    public Vector3 originPos = new Vector3(-8f, 2f, 198f);
    public GameObject objectToSpawn = null;
    public int minObstacle = 0;
    public int maxObstacle = 0;
    public GameObject enemyToSpawn = null;
    public int minEnemy = 0;
    public int maxEnemy = 0;
    public GameObject projectileFX;
    public GameObject explosionFX;

    void Start()
    {
        for (uint i = 0; i < maxCubes; ++i)
        {
            positions[i] = i;
        }
    }
    
    void Spawn()
    {
        // if invalid range, return without spawning
        if (minObstacle < 0 || maxObstacle + maxEnemy > maxCubes || minEnemy < 0 
            || minObstacle > maxObstacle || minEnemy > maxEnemy) return;

        Shuffle();

        int cubeNumber = Random.Range(minObstacle, maxObstacle + 1);
        int enemyNumber = Random.Range(minEnemy, maxEnemy + 1);
        
        float x, y;
        for (int i = 0; i < cubeNumber + enemyNumber; ++i)
        {
            // get position
            uint pos = positions[i];
            x = originPos.x + ((positions[i] % 5) * 4);
            y = originPos.y + ((positions[i] / 5) * 4);

            if (i < cubeNumber)
            {
                // spawn object
                Instantiate(objectToSpawn, new Vector3(x, y, originPos.z), Quaternion.identity);
            }
            else
            {
                Enemy inst = Instantiate(enemyToSpawn, new Vector3(x, y, originPos.z), Quaternion.identity * Quaternion.Euler(0, 180, 0)).GetComponent<Enemy>();
                inst.projectileFX = projectileFX;
                inst.explosionFX = explosionFX;
                inst.initShootDelay = Random.Range(0f, 1f);
            }
        }
    }

        
    public void Shuffle() 
    {
        for (int i = 0; i < maxCubes; ++i)
        {
            int rnd = Random.Range(0, maxCubes);
            tempPos = positions[rnd];
            positions[rnd] = positions[i];
            positions[i] = tempPos;
        }
    }
}
