using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 10, jumpVelocity = 10;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    public RobotAnimation robot;
    Transform myTrans, tagGround;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    bool willJump = false;
    bool isGrounded = false;
    float hInput = 0;

    private Vector2 _lastCheckpointPos;

    void Start()
    {
        _lastCheckpointPos = transform.position;

        //  myBody = this.rigidbody2D;//Unity 4.6-
        myBody = this.GetComponent<Rigidbody2D>();//Unity 5+
        myCollider = this.GetComponent<BoxCollider2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            willJump = true;
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        tagGround.transform.SetPositionAndRotation(transform.position, transform.rotation);
        tagGround.Translate(0f, -0.5f, 0f, Space.Self);

        float moveAxis = Input.GetAxisRaw("Horizontal");

        Move(moveAxis);

        if (willJump)
        {
            Jump();
            willJump = false;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            Respawn();
        }
    }

    void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        myBody.AddForce(transform.right * horizonalInput * speed);
        robot.SpeedPercent = transform.InverseTransformDirection(myBody.velocity).x / speed * 5;

        if (horizonalInput != 0.0f)
        {
            Vector3 scale = gameObject.transform.localScale;

            scale.x = Mathf.Sign(horizonalInput) * Mathf.Abs(scale.x);
            gameObject.transform.localScale = scale;
        }
    }

    public void Jump()
    {
        if (isGrounded)
            myBody.AddForce(transform.up * jumpVelocity);
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }

    public void Respawn()
    {
        transform.position = _lastCheckpointPos;
    }

    public void SetCheckpointPos(Vector3 vector3)
    {
        _lastCheckpointPos = vector3;
    }
}
