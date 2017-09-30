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

    private int _count = 0;

    private void Reset()
    {
        _lineRenderer = GetComponent<LineRenderer>();
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
            if (transform.childCount != _lineRenderer.positionCount)
                _lineRenderer.positionCount = transform.childCount;

            for (int i = 0; i < transform.childCount; i++)
                _lineRenderer.SetPosition(i, transform.GetChild(transform.childCount - 1 - i).localPosition);
        }
    }

    public void ApplyToCollider()
    {
        if (_collider)
        {
            Vector2[] path = new Vector2[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                int curId = i;
                Vector2 curPos = transform.GetChild(curId).localPosition;
                path[i] = curPos;
            }

            _collider.SetPath(0, path);
        }
    }
}
