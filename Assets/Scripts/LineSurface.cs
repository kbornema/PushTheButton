using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(LineRenderer))]
public class LineSurface : MonoBehaviour 
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    [SerializeField]
    private PolygonCollider2D _collider;

    [SerializeField]
    private int _updateCount = 10;

    [SerializeField]
    private bool _updatePositions;

    [SerializeField]
    private Transform _pointRoot;
    public Transform PointRoot { get { return _pointRoot; } set { _pointRoot = value; } }

    private int _count = 0;

    private void Reset()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Awake()
    {
        ApplyToCollider();
    }

    private void Update()
    {   
        if (Application.isEditor && !Application.isPlaying && _updatePositions)
        {   
            _count++;

            if(_count >= _updateCount)
            {
                _count = 0;
                ApplyPositions();
            }
        }
    }

    public void ApplyPositions()
    {
        if(_lineRenderer)
        {
            if (_pointRoot.childCount != _lineRenderer.positionCount)
                _lineRenderer.positionCount = _pointRoot.childCount;

            for (int i = 0; i < _pointRoot.childCount; i++)
                _lineRenderer.SetPosition(i, _pointRoot.GetChild(_pointRoot.childCount - 1 - i).localPosition);
        }
    }

    public void ApplyToCollider()
    {
        if (_collider)
        {
            if (_lineRenderer.loop)
                SetLoppedCollider();
        }
    }


    private int GetOpposideId(int id, int totalCount)
    {
        int test = totalCount - 1 - id;
        return test;
    }

    private void SetLoppedCollider()
    {
        Vector2[] path = new Vector2[_pointRoot.childCount];

        for (int i = 0; i < _pointRoot.childCount; i++)
        {
            int curId = i;
            Vector2 curPos = _pointRoot.GetChild(curId).localPosition;
            path[i] = curPos;
        }

        _collider.SetPath(0, path);
    }
}
