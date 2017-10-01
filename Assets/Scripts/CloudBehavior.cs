using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour 
{

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer TheSpriteRenderer { get { return _spriteRenderer; } }

    [SerializeField]
    private Transform _planetCenter;

    [SerializeField]
    private float _minSpeed;
    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private Vector3 _minScale = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField]
    private Vector3 _maxScale = new Vector3(1.5f, 1.5f, 1.5f);

    private float _speed;

	// Use this for initialization
	void Start () 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        var normal = transform.position - _planetCenter.position;
        float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle - 90.0f);

        _speed = Random.Range(_minSpeed, _maxSpeed);

        Vector3 scale = Vector3.Lerp(_minScale, _maxScale, Random.value);

        if(Random.value < 0.5f)
            scale.x = -scale.x;

        if (Random.value < 0.5f)
            scale.y = -scale.y;

        transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () 
    {
		transform.RotateAround(_planetCenter.position, new Vector3(0.0f, 0.0f, 1.0f), _speed * Time.deltaTime);
	}

    public void SetCenter(Transform t)
    {
        _planetCenter = t;
    }
}
