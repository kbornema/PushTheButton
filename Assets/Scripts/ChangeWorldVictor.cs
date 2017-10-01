using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWorldVictor : MonoBehaviour 
{
    [SerializeField]
    private ReplacePointsVictor _points;

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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Apply();
        }
    }
}
