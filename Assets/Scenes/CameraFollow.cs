using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;          // Drag the player here in Inspector tab
    //this is the camera smoothness lower the number the more smooth it is
    //make sure the camera offset on the z axis is set to -10 in the inspector tab or else the camera wont work 8==D
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
