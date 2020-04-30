using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 200;
    public int length = 512;
    public int height = 521;
    
    public float offsetY = 0;

    public float offsetXPerlin = 0;
    public int scale = 20;

    private Terrain terrain;
    
    // Start is called before the first frame update
    void Start()
    {
        offsetXPerlin = Random.Range(0f, 9999f);
        offsetY = transform.position.y;

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    // Update is called once per frame
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);   
    }

    TerrainData GenerateTerrain(TerrainData terrainData) 
    {
        terrainData.size = new Vector3(width, height, length);
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        float[,] heights = new float[width, length];
        for (int x = 0; x < width; ++x) {
            for (int y = 0; y < length; ++y) {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y) 
    {
        float xCoord = (float)x / width * scale + offsetXPerlin;
        float yCoord = (float)y / length * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
