using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float speedmultipler;
    public float speedIncreaseMilepost;
    private float speedMilepostCount;

    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myrigidbody;

    public bool grounded;
    public LayerMask ground;
    public LayerMask deathground;

    private Collider2D mycollider;
    private Animator myanimator;

    //public Transform groundcheck;
    //public float groundcheckradius;

    public GameManger thegameManger;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        mycollider = GetComponent<Collider2D>();
        myanimator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilepostCount = speedIncreaseMilepost;
        stoppedJumping = true;
    }

    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(mycollider, deathground);
        if (dead)
        {
            GameOver();
        }

        //grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, ground);

        if(transform.position.x > speedIncreaseMilepost)
        { 
            speedMilepostCount += speedIncreaseMilepost;
            speedIncreaseMilepost += speedIncreaseMilepost * speedmultipler;
            moveSpeed = moveSpeed * speedmultipler;
        }

        myrigidbody.velocity = new Vector2(moveSpeed, myrigidbody.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(mycollider, ground);

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
        {
            if (grounded)
            {
                jumpSound.Play();
                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
            }

            if(!grounded && canDoubleJump)
            {
                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                canDoubleJump = false;
                stoppedJumping = false;
                
            }
        }

        if((Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0 )
            {
                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }
       
        myanimator.SetBool("grounded", grounded);
    }

    void GameOver ()
    {
        thegameManger.GameOver();
    }
}
