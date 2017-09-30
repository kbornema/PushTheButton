using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAction : Triggerable {

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

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        fullAnimLength = animLength;
        startPosition = transform.position;
        endPosition = startPosition + offset;
        startRotation = transform.rotation.eulerAngles.z;
        endRotation = rotation + transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            if (animLength < 0 || animLength > fullAnimLength)
            {
                direction *= -1;
            }
            transform.position = Vector3.Lerp(startPosition, endPosition, animCurve.Evaluate((fullAnimLength - animLength)/fullAnimLength));
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(startRotation, endRotation, animCurve.Evaluate((fullAnimLength - animLength) / fullAnimLength)));
            animLength -= Time.deltaTime * direction;
	}

    public override void Trigger()
    {
        triggered = true;
    }
}
