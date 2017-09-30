using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(LineRenderer))]
public class LineSurface : MonoBehaviour 
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    [SerializeField]
    private int _updateCount = 10;

    [SerializeField]
    private bool _updatePositions;

    [SerializeField]
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
                _lineRenderer.SetPosition(i, transform.GetChild(i).localPosition);
        }

        /*
        if(_polygon)
        {

            Vector2[] path = new Vector2[transform.childCount];

            for (int i = 0; i < transform.childCount; i++)
            {
                int prevId = (i + transform.childCount - 1) % transform.childCount;
                int curId = i;
                int nextId = (i + 1) % transform.childCount;

                Vector2 prevPos = transform.GetChild(prevId).localPosition;
                Vector2 curPos = transform.GetChild(curId).localPosition;
                Vector2 nextPos = transform.GetChild(nextId).localPosition;



                Vector2 prevEdge = curPos - prevPos;
                Vector2 prevNormal = LeftNormal(prevEdge);
               // prevNormal.Normalize();

                Vector2 nextEdge = nextPos - curPos;
                Vector2 nextNormal = LeftNormal(nextEdge);

                Vector2 cornerNormal = Vector2.Lerp(prevNormal, nextNormal, _amointPercent);
                //cornerNormal.Normalize();

                //Debug.DrawRay(curPos, cornerNormal, Color.red, 0.5f);

                path[i] = curPos + cornerNormal * _cornerOffset;
            }

            _polygon.SetPath(0, path);
            
        }
         * */
    }

    private Vector2 LeftNormal(Vector2 v)
    {
        return new Vector2(-v.y, v.x);
    }

    private Vector2 RightNormal(Vector2 v)
    {
        return new Vector2(v.y, -v.x);
    }
}
