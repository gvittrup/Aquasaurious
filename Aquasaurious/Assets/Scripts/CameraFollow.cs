using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target, leftBound, rightBound, topBound, bottomBound;
    
    // Camera transition speed
    public float smoothSpeed = 0.125f;

    // Controls the maximum angle the camera will pivot to compensate the player
    // moving to the outer bounds of the play area
    public float cameraBoundAngle = 10f;

    // Dampens the `lookAt` X and Y target when moving away from the center of the screen
    public float lookAtOffset = 2.5f;

    // Camera offset for controlling starting distance from player
    public Vector3 offset;

    private Vector3 lookAt;
    private Vector3 boundaries;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate() {

        // Creates the boundaries for the camera
        lookAt = new Vector3(target.position.x / lookAtOffset, target.position.y / lookAtOffset, target.position.z);

        // X Bound
        if(target.position.x > 0)
            boundaries.x = Mathf.Lerp(0f, cameraBoundAngle, target.position.x / (rightBound.position.x / 2));
        else boundaries.x = Mathf.Lerp(0f, -cameraBoundAngle, target.position.x / (leftBound.position.x / 2));

        // Y Bound
        if(target.position.y > 0) 
            boundaries.y = Mathf.Lerp(0f, cameraBoundAngle, target.position.y / (topBound.position.y / 2));
        else boundaries.y = Mathf.Lerp(0f, -cameraBoundAngle, target.position.y / (bottomBound.position.y / 2));

        //Creates the target position for the camera
        Vector3 desiredPosition = target.position + offset - boundaries;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        
        //Sets the camera's position and angle
        transform.position = smoothedPosition;
        transform.LookAt(lookAt);
    }

}
