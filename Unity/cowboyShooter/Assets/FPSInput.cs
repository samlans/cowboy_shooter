using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    
    // Start is called when an object is first active.
    void Start() 
    {
        _charController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; 
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(
            deltaX ,
            0,
            deltaZ
        );
        movement = Vector3.ClampMagnitude(movement, speed);     
        
        // Transform the movement vector from local to global coordinates.
        movement = transform.TransformDirection(movement);
        movement.y = gravity;

        _charController.Move(movement);

    }
}
