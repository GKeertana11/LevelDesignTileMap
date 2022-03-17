using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnotherMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    Rigidbody2D rb;
    Vector2 movement;
    Animator animator;
    SpriteRenderer sprite;
    public bool isgrounded = true;
    public float score;
    public Text scoreText;
    public float score1;
    public Text scoreText1;
    public Text gameOver;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
      
    }
    void Start()
    {

    }
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement.x>0)
        {
            sprite.flipX = false;
        }
        if (movement.x < 0)
        {
            sprite.flipX = true;
        }
        animator.SetFloat("IsRunning", movement.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }
    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * playerSpeed, rb.velocity.y);
    }

    private void PlayerJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetBool("isJump", true);
        isgrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
        if (collision.gameObject.tag == "Platform")
        {
            animator.SetBool("isJump", false);
        }
        if (collision.gameObject.tag == "Cherry")
        {
            Destroy(collision.gameObject);
            score = score + 1;
            scoreText.text = score.ToString();

        }
        if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            score1 = score1 + 1;
            scoreText1.text = score1.ToString();

        }
        if (collision.gameObject.tag == "Enemey" && animator.GetBool("isJump") == true)
        {
            Destroy(collision.gameObject);

        }
      /*  if (collision.gameObject.tag == "Enemey")
        {
            Destroy(collision.gameObject);
            gameOver.GetComponent<Text>().enabled = true;

        }*/
    }
    }



