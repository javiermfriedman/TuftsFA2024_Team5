using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    //public Animator anim;
     Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask groundFrontLayer;
    public LayerMask groundBackLayer;
    public LayerMask enemyLayer;
    public bool canJump = false;
    public int jumpTimes = 0;
    // public bool isAlive = true;
    //public AudioSource JumpSFX;

    void Start()
    {
        //anim = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log("jump is at : " + jumpTimes);
        if ((IsGrounded()) && (jumpTimes == 0))
        {
            // if ((IsGrounded()) && (jumpTimes <= 1)){ // for single jump only
            // Debug.Log("jump yes");
            canJump = true;
        }
        else
        {
            // Debug.Log("cant jump 2");
            // else { // for single jump only
            canJump = false;
        }

        if ((Input.GetButtonDown("Jump")) && (canJump))
        {
            Debug.Log("bruh");
            Jump();
        }
    }

    public void Jump()
    {
        jumpTimes += 1;
        rb.velocity = Vector2.up * jumpForce;
        // anim.SetTrigger("Jump");
        // JumpSFX.Play();

        //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        //rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 2f, groundLayer);
        Collider2D groundFrontCheck = Physics2D.OverlapCircle(feet.position, 2f, groundFrontLayer);
        Collider2D groundBackCheck = Physics2D.OverlapCircle(feet.position, 2f, groundBackLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);
        if ((groundCheck != null) || (groundFrontCheck != null) || (groundBackCheck != null) || (enemyCheck != null))
        {
            Debug.Log("I am trouching ground!");
            jumpTimes = 0;
            return true;
        } else {
            Debug.Log("nno ground!");
            return false;
        }
        return false;
        
    }
}
