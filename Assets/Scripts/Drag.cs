using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public float drag = 5;
    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        myBody.AddForce(transform.right * -drag * transform.InverseTransformDirection(myBody.velocity).x);
	}
}
