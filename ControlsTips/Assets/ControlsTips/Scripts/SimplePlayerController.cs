using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{

    public float speed = 10;
    public float turnSpeed = 10;
    public float distToGround = 0;
    public float jumpForce = 10;


    // Update is called once per frame
    void Update()
    {
        ControlsTipsController();
        RotateInLookDirection();
    }

    private void FixedUpdate()
    {
        Jump();
        Controls();
    }

    void RotateInLookDirection()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 currentRotation = new Vector3(h, 0f, v);
            Quaternion lookRotation = Quaternion.LookRotation(currentRotation, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
        }
    }

    void Controls()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
    }

    void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (isGrounded() && Input.GetKeyDown(KeyCode.Q))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void ControlsTipsController()
    {
        if (isGrounded())
        {
            ControlsTips.Instance.ShowTip("Jump");
        }
        else
        {
            ControlsTips.Instance.HideTip("Jump");
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
