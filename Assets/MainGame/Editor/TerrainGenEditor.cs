using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (MeshGenerator))]
public class TerrainGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MeshGenerator terGen = (MeshGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate"))
        {
            terGen.EditorGenerate();
        }
    }
}
