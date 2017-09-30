using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform planet;
    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    bool isGrounded = false;
    float hInput = 0;

    void Start()
    {
        //  myBody = this.rigidbody2D;//Unity 4.6-
        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+
        myCollider = this.GetComponent<BoxCollider2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    void FixedUpdate()
    {

        transform.up = transform.position - planet.position;
        tagGround.transform.SetPositionAndRotation(transform.position, transform.rotation);
        tagGround.Translate(0f, -0.3f, 0f, Space.Self);

        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);


        myBody.AddForce(transform.up * -20f);

        


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
        myBody.AddForce(transform.right * horizonalInput * speed);
    }

    public void Jump()
    {
        if (isGrounded)
            myBody.AddForce(transform.up*jumpVelocity);
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }
}
