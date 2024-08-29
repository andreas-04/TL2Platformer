using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;     // Reference to the player's transform
    public Vector3 offset;       // Offset between the camera and player
    public float smoothSpeed = 0.125f; // Smooth movement speed

    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
