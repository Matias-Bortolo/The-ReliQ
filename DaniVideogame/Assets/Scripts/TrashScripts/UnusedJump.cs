using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnusedJump : MonoBehaviour
{
    /*public float playerSpeed;
    public float jumpForce;
    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        Vector3 inputVector;
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = 0;
        inputVector.z = Input.GetAxisRaw("Vertical");

        RB.MovePosition(RB.position + (transform.right * inputVector.x + transform.forward * inputVector.z) * playerSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }*/
}
