using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour {

    [SerializeField]
    private Transform _planetCenter;

    [SerializeField]
    private float _minSpeed;
    [SerializeField]
    private float _maxSpeed;

    private float _speed;

	// Use this for initialization
	void Start () 
    {
        var normal = transform.position - _planetCenter.position;
        float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle - 90.0f);

        _speed = Random.Range(_minSpeed, _maxSpeed);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
		transform.RotateAround(_planetCenter.position, new Vector3(0.0f, 0.0f, 1.0f), _speed * Time.deltaTime);
	}
}
