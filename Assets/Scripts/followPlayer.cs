using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    public float _upOffset;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private bool _rotateWithCharacter;
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector3 localOffset = player.up * _upOffset;

        Vector2 toTarget = (player.position + localOffset) - transform.position;

        

        Vector3 bla = toTarget * Time.fixedDeltaTime * _speed;


        Vector3 newPos = transform.position + bla;



        transform.position = newPos;
        

        if(_rotateWithCharacter)
            transform.rotation = player.rotation;
	}
}
