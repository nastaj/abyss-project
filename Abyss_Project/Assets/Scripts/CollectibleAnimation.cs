using UnityEngine;

public class CollectibleAnimation : MonoBehaviour
{
    public float spinSpeed = 100f;  // Speed of rotation, adjust as needed
    public float moveSpeed = 0.5f; // How far the object moves up and down
    public float moveRange = 0.2f; // Range of the up-and-down movement

    private Vector3 startPosition;  // Initial position of the collectible

    void Start()
    {
        // Store the initial position when the game starts
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the collectible around its X axis
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);

        // Make the collectible move up and down smoothly
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveRange + startPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
