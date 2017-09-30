using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcPointMesh : MonoBehaviour 
{
    [SerializeField]
    private Transform _pointRoot;
    [SerializeField]
    private MeshRenderer _renderer;
    [SerializeField]
    private MeshFilter _meshFilter;

    void Awake()
    {
        GenerateMesh(_pointRoot);
    }

    private void GenerateMesh(Transform root)
    {
        Vector2[] inputVertices = new Vector2[root.childCount];

        for (int i = 0; i < root.childCount; i++)
            inputVertices[i] = root.GetChild(i).position;

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(inputVertices);
        int[] indices = tr.Triangulate();

        Vector2[] uvs = new Vector2[root.childCount];

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[inputVertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(inputVertices[i].x, inputVertices[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.uv = uvs;
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();
        

        _meshFilter.mesh = msh;

        
    }


}
