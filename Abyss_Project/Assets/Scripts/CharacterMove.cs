using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 3.5f; // Speed of movement
    public float rotationSpeed = 5.0f; // Speed of rotation
    public float gravity = 9.81f; // Gravity effect
    public float groundCheckDistance = 0.2f; // Distance to check for ground

    private Animator animator;
    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PatrolMovement();
        ApplyGravity();
        controller.Move(moveDirection * Time.deltaTime);
    }

    void PatrolMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);

            // Rotate character to face movement direction
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Move in the desired direction
            moveDirection = transform.forward * moveSpeed;
        }
        else
        {
            animator.SetBool("isMoving", false);

            moveDirection.x = 0;
            moveDirection.z = 0;
        }
    }

    void ApplyGravity()
    {
        // Check if character is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        if (!isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = -0.1f; // Keeps character grounded
        }
    }
}
