using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimation : MonoBehaviour 
{
    [SerializeField]
    private float _maxMoveTiltDegree;

    [SerializeField, Range(0.0f, 1.0f)]
    private float _speedPercent;
    public float SpeedPercent { get { return _speedPercent; } set { _speedPercent = value; } }

    [SerializeField]
    private Transform _root;

    public float FlipScale { get { return Mathf.Sign(_root.localScale.x); } }

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, _maxMoveTiltDegree * _speedPercent * FlipScale);
    }
}
