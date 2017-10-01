using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Triggerable
{
    [SerializeField]
    private float _time = 1.0f;
    
    [SerializeField]
    private Transform _targetPos;

    [SerializeField]
    private AnimationCurve _curve;

    private Vector3 _startPos;
    private Vector3 _endPos;
    private float _curTime;

    private void Awake()
    {
        _startPos = transform.position;
        _endPos = _targetPos.position;
        enabled = false;
    }

    public override void Trigger()
    {
        enabled = true;
    }

    private void Update()
    {
        _curTime += Time.deltaTime;

        float t = _curTime / _time;

        float lerpT = _curve.Evaluate(t);

        transform.position = Vector3.Lerp(_startPos, _endPos, lerpT);

        if(t >= 1.0f)
            enabled = false;
    }
}
