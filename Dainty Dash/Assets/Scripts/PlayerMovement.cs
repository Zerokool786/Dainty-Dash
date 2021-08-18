using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    private float animationDelay = 3.0f;
    private float playerSpeed = 3.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    public float jumpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < animationDelay)                                                  // starts at zero to 3 secs restrict player movement while swerve finishes
        {
            controller.Move(Vector3.forward * playerSpeed * Time.deltaTime);
            return;                                                                     // if delay is less than 3 secs return or else activate controls
        }
        
        
        moveVector = Vector3.zero;                                     //update movment with every frame

        if(controller.isGrounded)   
        {
            verticalVelocity = -0.5f;                                  //realistic 
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * playerSpeed;    //left & right

        moveVector.y = verticalVelocity;

        moveVector.z = playerSpeed;                                     //constant forward value 

        controller.Move((moveVector) * Time.deltaTime);

        transform.Translate(0, jumpSpeed * Input.GetAxis("Jump") * Time.deltaTime, 0);
    }
}
