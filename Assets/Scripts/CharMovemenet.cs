using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Character only moves in x and z axis
//looks at the direction of movement
//gravity is onto rigidbody

public class CharMovemenet : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotationSmooth = 1.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if(moveDirection.magnitude > 0.1f)
        { 
        controller.Move(moveDirection * Time.deltaTime);
        }
        if (moveDirection != Vector3.zero)
        {
            float smoothfactor= rotationSmooth;
            //rotates 2x slower if moveDirection is the opposite of previous one
            if(Vector3.Angle(transform.forward, moveDirection) > 170f || Vector3.Angle(transform.forward, moveDirection) < -170) smoothfactor*=2;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f/smoothfactor);
        }
    }
}
