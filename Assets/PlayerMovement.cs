using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
   public  Rigidbody2D rb;
   public Vector2 movement;
    public Animator Animator;
    public float jumpForce;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
       
            movement.x = Input.GetAxis("Horizontal");
        
        
        movement.y = Input.GetAxis("Vertical");
        if(movement.x>0)
        {
            sprite.flipX = false;
        }
       else if (movement.x < 0)
        {
            sprite.flipX = true;
        }

        Animator.SetFloat("IsRunning",movement.sqrMagnitude);
        if(Input.GetKeyDown(KeyCode.Space))

        {
            Animator.SetFloat("IsJump", 1);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space))

        {
            rb.AddForce(new Vector2(0f, movement.y*jumpForce),ForceMode2D.Impulse);
            Animator.SetFloat("IsJump", 1);
        }
    }
}
