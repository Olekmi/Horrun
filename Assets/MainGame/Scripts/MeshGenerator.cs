using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    // grid settings
    public int xSize = 50;
    public int zSize = 50;
    public Gradient gradient;
    public float maxTerrainHeight = 5f;
    public float heightModifier = 5f;
    // grid settings - perlin noise offsets
    public float perlinOffsetX = 0;
    public float perlinOffsetY = 0;
    public float perlinScale = .3f;

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Color[] colours;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //CreateShape();
        //UpdateMesh();
        transform.Translate(Vector3.back * Time.deltaTime * DifficultyHandler.Instance.scrollSpeed);

        if (transform.position.z <= -50)
        {
            perlinOffsetY += 200;

            CreateShape();
            UpdateMesh();

            transform.Translate(Vector3.forward * 200);
        }
    }

    public void EditorGenerate()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMeshEditor();
    }

    void CreateShape()
    {
        // generate vertices
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        float heightLimiter = 0;
        float xSizeHalf = (float)xSize / 2;
        for (int i = 0, z = 0; z <= zSize; ++z)
        {
            for (int x = 0; x <= xSize; ++x)
            {
                heightLimiter = Mathf.Max((Mathf.Abs(x - xSizeHalf) - 10) / (xSizeHalf - 10), 0);
                float y = (Mathf.PerlinNoise((x + perlinOffsetX) * perlinScale, (z + perlinOffsetY) * perlinScale) * maxTerrainHeight + heightModifier) * heightLimiter;

                vertices[i] = new Vector3(x, y, z);
                ++i;
            }
        }

        triangles = new int[xSize * zSize * 6];

        // draw quads between vertices
        for (int vert = 0, tris = 0, z = 0; z < zSize; ++z)
        {
            for (int x = 0; x < xSize; ++x)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                ++vert;
                tris += 6;
            }
            ++vert;
        }

        // colour the vertices based on height
        colours = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; ++z)
        {
            for (int x = 0; x <= xSize; ++x)
            {
                float height = Mathf.InverseLerp(0, maxTerrainHeight + heightModifier, vertices[i].y);
                colours[i] = gradient.Evaluate(height);
                ++i;
            }
        }
    }

    void UpdateMesh()
    {
        // delete old data
        mesh.Clear();

        // load in generated data
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colours;

        // recalculate lighting
        mesh.RecalculateNormals();

        // collision
        mesh.RecalculateBounds();
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    void UpdateMeshEditor()
    {
        // delete old data
        mesh.Clear();

        // load in generated data
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colours;

        // recalculate lighting
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null) return;

        for (int i = 0; i < vertices.Length; ++i)
        {
            Gizmos.DrawSphere(vertices[i] + transform.position, .1f);
        }
    }
}
