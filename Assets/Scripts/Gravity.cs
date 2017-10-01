using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public Transform planet;
    Rigidbody2D myBody;
    public float gravity = 50;
    public bool alwaysStandingUp;
    Vector2 normal;

    void Start()
    {
        //  myBody = this.rigidbody2D;//Unity 4.6-
        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+

    }

	// Update is called once per frame
	void FixedUpdate () {

        normal = transform.position - planet.position;
        
        if (alwaysStandingUp)
        {
            float angle = Mathf.Atan2(normal.y, normal.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle - 90.0f);
        }
            

        myBody.AddForce(normal * -gravity);

	}
}
