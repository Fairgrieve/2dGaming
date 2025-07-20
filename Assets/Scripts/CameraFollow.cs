using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    // This script makes the camera follow a target object smoothly.
    // Set the target in the inspector to the object you want the camera to follow.
    // Change the z axis offset to adjust the camera's distance from the target.
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    // tHIS is the soomthing time fot the camera to catch up with the target. 
    // Adjust this value to make the camera follow faster or slower.
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        // Check if the target is assigned
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}