using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRotation : MonoBehaviour 
{   
    [SerializeField]
    private float _maxRotationSpeed;

    [SerializeField]
    private RobotAnimation _robotAnimation;
	
	// Update is called once per frame
	private void Update () 
    {
        transform.Rotate(0.0f, 0.0f, _maxRotationSpeed * _robotAnimation.SpeedPercent * Time.deltaTime, Space.Self);
	}
}
