using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2D;
   // private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 8f;
    public float startSpeed = 8f;
    public bool isAlive = true;
    private Vector3 hMove;

    // Add a flag for auto-running
    public bool isAutoRunning = true;

    void Start()
    {
        rb2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAlive)
        {
            // If auto-run is enabled, move automatically to the right
            if (isAutoRunning)
            {
                hMove = new Vector3(1.0f, 0.0f, 0.0f); // Always move to the right
            }
            else
            {
                // Allow manual control when auto-run is disabled
                hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            }

            transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

            // Check if the player should be turning
            //if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight))
          //  {
           //     playerTurn();
          //  }
        }
    }

    void FixedUpdate()
    {
        // Slow down on hills / stops sliding from velocity
        if (hMove.x == 0 && !isAutoRunning)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y);
        }
    }

    private void playerTurn()
    {
        // Switch player facing direction
       // FaceRight = !FaceRight;

        // Multiply player's x local scale by -1 to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}