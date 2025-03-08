using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Character only moves in x and z axis
//looks at the direction of movement
//works with rigidbody
//rotates smoothly

public class CharMovemenet : MonoBehaviour
{
    public float speed = 5.0f;
    public float GravityFactor = 1.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private float horizontalInput;
    private float verticalInput;
    
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        lookDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        //check if the player is grounded 
        //raycast and check if the casted ray hits the ground layer
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.6f))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }

        //gravity
        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * GravityFactor);
        }
    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.15f);
        }
    }
}
