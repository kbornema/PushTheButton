using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour 
{
    [SerializeField]
    private ReplacePoints _points;

    [SerializeField]
    private LineSurface _planetSurface;

    [SerializeField]
    private ProcPointMesh _insidePlanet;

    [ContextMenu("Bla")]
    public void Apply()
    {

        _planetSurface.PointRoot = _points.NewPointRoot;
        _planetSurface.ApplyPositions();
        _planetSurface.ApplyToCollider();

        if(_insidePlanet)
        {
            _insidePlanet.PointRoot = _points.NewPointRoot;
            _insidePlanet.GenerateMesh();
        }        

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Apply();
        }
    }
}
