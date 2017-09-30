using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LineSurface))]
public class LineSurfaceEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Apply To Collider"))
        {
            (target as LineSurface).ApplyToCollider();
        }
    }
}
