using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Triggerable
{
    [SerializeField]
    private Transform _movingObj;

    [SerializeField]
    private float _time = 1.0f;
    
    [SerializeField]
    private Transform _targetPos;
    [SerializeField]
    private Transform _startPos;

    [SerializeField]
    private bool _setStartAsStart;

    [SerializeField]
    private AnimationCurve _curve;

    private Vector3 _startVec;
    private Vector3 _endVec;
    private float _curTime;

    private void Awake()
    {
        _startVec = _startPos.position;
        _endVec = _targetPos.position;
        enabled = false;

        if (_setStartAsStart)
            _movingObj.position = _startVec;
    }

    public override void Trigger()
    {
        if(!enabled)
        {
            enabled = true;
            _curTime = 0.0f;
        }

    }

    private void Update()
    {
        _curTime += Time.deltaTime;

        float t = _curTime / _time;

        float lerpT = _curve.Evaluate(t);

        _movingObj.position = Vector3.Lerp(_startVec, _endVec, lerpT);

        if(t >= 1.0f)
        {
            enabled = false;
        }
    }
}
