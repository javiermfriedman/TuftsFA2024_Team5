using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndColliderScript : MonoBehaviour
{
    // Reference to the player move script
    private PlayerMove playerMove;
    //public GameObject player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // You can find the PlayerMove script if it's on a specific player object.
        // Assuming there's only one player, you can use the following line:
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        Debug.Log(anim);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("Player reached the end!");

    //         // Stop the player from moving
    //         if (playerMove != null)
    //         {
    //             playerMove.isAlive = false;      // Stop player movement
    //             playerMove.isAutoRunning = false; // If you want to stop auto-running as well
    //             anim.SetBool("Win", true);
    //         }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player reached the end!");

            // Stop the player from moving
            if (playerMove != null)
            {
                playerMove.isAlive = false;      // Stop player movement
                playerMove.isAutoRunning = false; // Stop auto-running
                anim.SetBool("Win", true); // Trigger backflip animation
                
                // Start coroutine to wait for the animation to finish
                StartCoroutine(WaitForBackflip());
            }
        }
    }

    // Coroutine to wait for the backflip animation to finish before loading the "YouWin" scene
    IEnumerator WaitForBackflip()
    {
        // Assuming the backflip animation lasts 2 seconds
        yield return new WaitForSeconds(2.0f);

        // Load the "YouWin" scene
        SceneManager.LoadScene("WinScene");
    }
}