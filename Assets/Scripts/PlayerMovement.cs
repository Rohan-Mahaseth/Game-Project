using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // How fast the player moves
    public float moveSpeed = 5f;

    // Gravity applied to the player
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        // Find the Character Controller attached to the Player
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get keyboard input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create movement direction
        Vector3 move = transform.right * horizontal +
                       transform.forward * vertical;

        // Move the player
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Keep player grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}