using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform planet;
    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    bool isGrounded = false;
    float hInput = 0;

    void Start()
    {
        //  myBody = this.rigidbody2D;//Unity 4.6-
        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

            Vector3 toTarget = transform.position - planet.position;
            float angle = Mathf.Atan2(toTarget.y, toTarget.x);
            transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg + 90);


        #if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
            Move(Input.GetAxisRaw("Horizontal"));
            if (Input.GetButtonDown("Jump"))
                Jump();
        #else
            Move (hInput);
        #endif

    }

    void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if (isGrounded)
            myBody.velocity += jumpVelocity * Vector2.up;
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }
}
