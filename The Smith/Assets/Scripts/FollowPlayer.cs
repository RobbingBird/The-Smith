using UnityEngine;

public class FollowPlayer: MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned in the CameraFollow script.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to match the player's position with an offset
            Vector3 newPosition = player.position + offset;
            transform.position = newPosition;
        }
    }
}

