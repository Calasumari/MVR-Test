using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Create variables needed for movement
    public float moveSpeed;
    public Transform direction;
    public float dragForce;

    float horizontalIn;
    float verticalIn;

    Vector3 moveDirection;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    private void Update()
    {
        MyInput();
        maxSpeed();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void MyInput()
    {
        horizontalIn = Input.GetAxisRaw("Horizontal");
        verticalIn = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        moveDirection = direction.forward * verticalIn + direction.right * horizontalIn;
        rb.AddForce(moveDirection.normalized * moveSpeed * 1f, ForceMode.Force);
        rb.drag = dragForce;
    }

    void maxSpeed()
    {
        Vector3 baseVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(baseVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = baseVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
