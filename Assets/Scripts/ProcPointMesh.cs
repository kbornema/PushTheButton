using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcPointMesh : MonoBehaviour 
{
    [SerializeField]
    private int _orderInLayer;
    [SerializeField]
    private string _layerName;
    [SerializeField]
    private Transform _pointRoot;
    public Transform PointRoot { get { return _pointRoot; } set { _pointRoot = value; } }

    [SerializeField]
    private MeshRenderer _renderer;
    [SerializeField]
    private MeshFilter _meshFilter;
    [SerializeField]
    private Color _color;

    private void Awake()
    {
        GenerateMesh();
    }

    public void GenerateMesh()
    {
        Vector2[] inputVertices = new Vector2[_pointRoot.childCount];

        for (int i = 0; i < _pointRoot.childCount; i++)
            inputVertices[i] = _pointRoot.GetChild(i).localPosition;

        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(inputVertices);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[inputVertices.Length];

        for (int i = 0; i < vertices.Length; i++)
            vertices[i] = new Vector3(inputVertices[i].x, inputVertices[i].y, 0);

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        //msh.colors = colors;
        //msh.uv = uvs;
        msh.RecalculateNormals();
        msh.RecalculateBounds();
        

        _meshFilter.mesh = msh;
        _renderer.sharedMaterial.color = _color;
        _renderer.sortingLayerID = SortingLayer.NameToID(_layerName);
        _renderer.sortingOrder = _orderInLayer;
    }


}
