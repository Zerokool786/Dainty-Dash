using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;


    private float swerve = 0.0f;
    private float animationDelay = 3.0f;
    private Vector3 animationOffset = new Vector3(0,5,5); //start camera pan from y finish transition to z

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;

        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;   //opens up x and y modifications for the camera follow

        moveVector.x = 0;                             // horizontal stays middle when player turns left or right

        moveVector.y = Mathf.Clamp(moveVector.y, 2, 5);


        if (swerve > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, swerve);

            swerve += Time.deltaTime * 1 / animationDelay;    //1*1/2 = 0.5 two seconds to start the gameplay

            transform.LookAt(lookAt.position + Vector3.up);     // pan towards player rather than straight during initial start
        }


        transform.position = moveVector;              
    }
}
