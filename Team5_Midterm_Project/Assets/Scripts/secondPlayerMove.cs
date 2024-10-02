using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 10f;
    public float startSpeed = 10f;
    public bool isAlive = true;
    private Vector3 hMove;

    // Add a flag for auto-running
    public bool isAutoRunning = true;

    // Jumping variables
    public float jumpForce = 5f; // Smaller jump force
    public bool isGrounded = true;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    void Start()
    {
        rb2D = transform.GetComponent<Rigidbody2D>();

        // Make gravity stronger so the player falls faster
        rb2D.gravityScale = 3.0f; // Increase gravity to make falling faster
    }

    void Update()
    {
        if (isAlive)
        {
            // Horizontal movement
            if (isAutoRunning)
            {
                hMove = new Vector3(1.0f, 0.0f, 0.0f); // Always move to the right
            }
            else
            {
                hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            }

            transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

            // Jumping: check if grounded, and if jump button (spacebar) is pressed
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            // Check if the player should turn
            if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight))
            {
                playerTurn();
            }
        }
    }
    private void Jump()
    {
        // Add a vertical force to the player to simulate jumping
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }

    private void playerTurn()
    {
        // Switch player facing direction
        FaceRight = !FaceRight;

        // Multiply player's x local scale by -1 to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
