using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
[AddComponentMenu ("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    float moveSpeed;
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 8f;
    public float jumpSpeed = 40f;
    public float gravity = 0.5f;
    private CharacterController _charController;

    Vector3 moveDirection;

    // Start is called when an object is first active.
    void Start () {
        _charController = GetComponent<CharacterController> ();
    }
    // Update is called once per frame
    void Update () {
        Move ();
    }

    void Move () {
        float deltaX = Input.GetAxis ("Horizontal");
        float deltaZ = Input.GetAxis ("Vertical");

        if (_charController.isGrounded) {
            moveDirection = new Vector3 (deltaX, 0, deltaZ);
            moveDirection = transform.TransformDirection (moveDirection);
            if (Input.GetKey (KeyCode.LeftShift) && deltaZ == 1)
                moveSpeed = sprintSpeed;
            else
                moveSpeed = walkSpeed;

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown (KeyCode.Space)) {
                moveDirection.y += jumpSpeed;
            }
            //Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            //movement = Vector3.ClampMagnitude(movement, speed);     
        }

        //movement *= Time.deltaTime;

        // Transform the movement vector from local to global coordinates.
        // movement = transform.TransformDirection(movement);
        moveDirection.y -= gravity;

        //_charController.Move(movement);
        _charController.Move (moveDirection * Time.deltaTime);

    }
}