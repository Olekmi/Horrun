using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject DifficultyManager;
    public const int maxCubes = 15;
    private uint[] positions = new uint[15];
    private uint tempPos;
    public Vector3 originPos = new Vector3(-8f, 2f, 198f);
    public GameObject objectToSpawn = null;
    public int min = 0;
    public int max = 0;

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
        if (min < 0 || max > maxCubes) return;

        Shuffle();

        int cubeNumber = Random.Range(min, max + 1);
        
        float x, y;
        GameObject instance;
        CubeObstacleBehaviour script;
        for (int i = 0; i < cubeNumber; ++i)
        {
            // get position
            uint pos = positions[i];
            x = originPos.x + ((positions[i] % 5) * 4);
            y = originPos.y + ((positions[i] / 5) * 4);
            
            // spawn object
            instance = Instantiate(objectToSpawn, new Vector3(x, y, originPos.z), Quaternion.identity);
            script = instance.GetComponent<CubeObstacleBehaviour>();
            script.DifficultyManager = DifficultyManager;
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
