using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerboat : MonoBehaviour
{

    //public Collision collision;

    //Variables
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
        //rb.freezeRotation = true;
        //acceleration = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        MaxSpeed();
        Debug.Log(Time.deltaTime);
      
    }

    private void FixedUpdate()
    {
        Move();
    }

    //using axis vs using key input means it naturally has acceleration/decelaration + can account for controller input
    void MyInput()
    {
        horizontalIn = Input.GetAxisRaw("Horizontal");
        verticalIn = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        moveDirection = (direction.forward * verticalIn + direction.right * horizontalIn);
        rb.AddForce(moveDirection.normalized * moveSpeed * 1f, ForceMode.Force);
        rb.drag = dragForce;
    }

    void MaxSpeed()
    {
        Vector3 baseVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (baseVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = baseVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }


   
}
