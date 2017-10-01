using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorld : MonoBehaviour 
{
    [SerializeField]
    private Transform _newPoints
    ;

    [SerializeField]
    private LineSurface _planetSurface;

    [SerializeField]
    private ProcPointMesh _insidePlanet;

    public void Apply()
    {
        _planetSurface.PointRoot = _newPoints;
        _planetSurface.ApplyPositions();
        _planetSurface.ApplyToCollider();

        if(_insidePlanet)
        {
            _insidePlanet.PointRoot = _newPoints;
            _insidePlanet.GenerateMesh();
        }        
    }
}
