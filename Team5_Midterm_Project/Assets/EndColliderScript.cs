using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndColliderScript : MonoBehaviour
{
    // Reference to the player move script
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        // You can find the PlayerMove script if it's on a specific player object.
        // Assuming there's only one player, you can use the following line:
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the end!");

            // Stop the player from moving
            if (playerMove != null)
            {
                playerMove.isAlive = false;      // Stop player movement
                playerMove.isAutoRunning = false; // If you want to stop auto-running as well
            }
        }
    }
}
