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

    float prevVelocityX;
    float prevVelocityZ;
    float currentVelocityX;
    float currentVelocityY;

    Vector3 moveDirection;
    

    Rigidbody rb;

    public float acceleration;
    public float deceleration;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        acceleration = 0.1f;

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
        moveDirection = (direction.forward * verticalIn + direction.right * horizontalIn) * acceleration;
        rb.AddForce(moveDirection.normalized * moveSpeed * 1f, ForceMode.Force);
        rb.drag = dragForce;
        /*if (acceleration < 1.0f)
        {
            /*float velocityX = prevVelocityX - rb.velocity.x;
            float velocityZ = prevVelocityZ - rb.velocity.z;
            float avgVelocity = (velocityX + velocityZ) / 2;
            acceleration = avgVelocity * Time.deltaTime;

            if (acceleration < 0f)
            {
                acceleration = acceleration + (2 * acceleration);
            }
            Debug.Log(acceleration);

            acceleration += 0.01f;
        }*/
        prevVelocityX = rb.velocity.x;
        prevVelocityZ = rb.velocity.z;
        Debug.Log(prevVelocityX + ", 0, " + prevVelocityZ); 
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
