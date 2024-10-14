using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask groundFrontLayer;
    public LayerMask groundBackLayer;
    public LayerMask enemyLayer;
    public bool canJump = false;
    public int jumpTimes = 0;
    public Animator anim;
    public bool isFalling;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponentInChildren<Animator>(); 
        Debug.Log(anim);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        isFalling = rb.velocity.y < 0? true : false;
        if (isFalling && !(IsGrounded()))
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }
    }

    public void Jump()
    {
        if ((IsGrounded()) && (jumpTimes <= 1))
        {
            canJump = true;
            jumpTimes += 1;
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Jump", true); 
        }
        else
        {
            canJump = false;
        }
    }

    public void OnCollisionEnter2D (Collision2D other) 
    {
        anim.SetBool("Fall", false);
        anim.SetBool("Jump", false);
        
        //Debug.Log("a");
    }


    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 2f, groundLayer);
        Collider2D groundFrontCheck = Physics2D.OverlapCircle(feet.position, 2f, groundFrontLayer);
        Collider2D groundBackCheck = Physics2D.OverlapCircle(feet.position, 2f, groundBackLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);
        if ((groundCheck != null) || (groundFrontCheck != null) || (groundBackCheck != null) || (enemyCheck != null))
        {
            //Debug.Log("I am trouching ground!");
            jumpTimes = 0;
            anim.SetBool("Jump", false); 
            return true;
        } else {
            //Debug.Log("nno ground!");
            return false;
        }
        return false;
        
    }
}
