using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{

    //Some help from https://www.youtube.com/watch?v=UCwwn2q4Vys

    [Header("References")]
    public Transform direction;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpd;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //Vector for the orientation
        Vector3 vierDir = playerObj.position - new Vector3(transform.position.x, playerObj.position.y, transform.position.z);
        direction.forward = vierDir.normalized;

        float horizontalIn = Input.GetAxis("Horizontal");
        float verticalIn = Input.GetAxis("Vertical");
        Vector3 inputDir = direction.forward * verticalIn + direction.right * horizontalIn;

        if(inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpd);

        }
    }
}
