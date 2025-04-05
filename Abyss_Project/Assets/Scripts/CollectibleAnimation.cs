using UnityEngine;

public class CollectibleAnimation : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationAxis = Vector3.up; // Customizable rotation axis
    public float spinSpeed = 100f;

    [Header("Float Animation Settings")]
    public float moveSpeed = 0.5f; 
    public float moveRange = 0.2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate around custom axis
        transform.Rotate(rotationAxis.normalized * spinSpeed * Time.deltaTime);

        // Float up and down
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveRange + startPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}