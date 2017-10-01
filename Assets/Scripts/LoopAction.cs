using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAction : Triggerable {

    public Transform _offsetTransform;
    public AnimationCurve animCurve;
    public Vector3 offset;
    public float rotation;
    float startRotation, endRotation;
    Vector3 startPosition, endPosition;
    public float animLength = 1;
    int direction = 1;
    float fullAnimLength;
    public bool triggered = false;
    Vector3 originalPosition;

    public float offsetPercent = 1.0f;
	// Use this for initialization
	void Start () {

        if (_offsetTransform)
            offset = _offsetTransform.position - transform.position;

        originalPosition = transform.position;
        fullAnimLength = animLength;
        animLength = animLength * offsetPercent;
        startPosition = transform.position;
        endPosition = startPosition + offset;
        startRotation = transform.rotation.eulerAngles.z;
        endRotation = rotation + transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (animLength < 0 || animLength > fullAnimLength)
            direction *= -1;
            
        float t = (fullAnimLength - animLength) / fullAnimLength;
        float evalT = animCurve.Evaluate(t);

        transform.position = Vector3.Lerp(startPosition, endPosition, evalT);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(startRotation, endRotation, evalT));
        animLength -= Time.deltaTime * direction;
	}

    public override void Trigger()
    {
        triggered = true;
    }
}
