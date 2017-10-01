using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProcPointMesh))]
public class ProcPointMeshEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generate"))
        {
            (target as ProcPointMesh).GenerateMesh();
        }
    }
}
