using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    [Header("Speed Settings")]
    public float walkSpeed = 7f;
    public float crawlSpeed=5f;
    public float jumpForce=11f;

    [Header("Collider Settings")]
    public Vector2 standSize=new Vector2(1f,2f);
    public Vector2 crawlSize=new Vector2(2f,1f);
    public Vector2 standOffset=new Vector2(0f,0.5f);
    public Vector2 crawlOffset=new Vector2(0f,0f);
    public bool doubleJumped=false; //tutorial
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Vector2 moveInput;
    private bool isGrounded;
    public bool isStanding=false;
    private Movement movement;
    private float currentSpeed;

    //Animation
    private Animator animator;
    private SpriteRenderer sr;
    private string currentState;
     private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        movement = new Movement();    //new input system class
        boxCollider=GetComponent<BoxCollider2D>();
        currentSpeed=crawlSpeed;
        boxCollider.size=crawlSize;
        boxCollider.offset=crawlOffset;
    }
    private void OnEnable()
    {
        movement.Enable();
        movement.player.Jump.performed += Jump;
        movement.player.Stand.performed+=Stand;
    }
    private void OnDisable()
    {
     movement.Disable();
     movement.player.Jump.performed -= Jump;
     movement.player.Stand.performed-=Stand;
    }  
    private void Update()
    {
        //read the movement input from the new input system
        moveInput=movement.player.Move.ReadValue<Vector2>();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        //move the player horizontally based on the input
        rb.linearVelocity = new Vector2(moveInput.x * currentSpeed, rb.linearVelocity.y);
    }
    private void Jump(InputAction.CallbackContext context)
    {   //first jump
        if(isGrounded&&isStanding)
        {
            rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            isGrounded=false;
        }

        //second jump
        else if (!isGrounded && !doubleJumped && isStanding)
        {
            if (GameManager.instance != null && GameManager.instance.doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); //reset vertical velocity before the second jump
                rb.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
                doubleJumped=true;
            }
        }
    }
    private void Stand(InputAction.CallbackContext context)
    {
        isStanding=!isStanding;
        if (isStanding)
        {
            currentSpeed=walkSpeed;
            boxCollider.size=standSize;
            boxCollider.offset=standOffset;
        }
        else
        {
            currentSpeed=crawlSpeed;
            boxCollider.size=crawlSize;
            boxCollider.offset=crawlOffset;
        }
    }
    private void UpdateAnimation()
    {
        //flip the sprite based on movement direction
        if (moveInput.x > 0)
        {
            sr.flipX = false; //face right
        }
        else if (moveInput.x < 0)
        {
            sr.flipX = true; //face left
        }
        string newState="";

        if (!isGrounded)
        {   //see if we are going up or down
            if(rb.linearVelocity.y > 0.1f)
            {
               newState="Jump right";
            }
            else
            {
                newState="fall right";
            }
        }
        //so player is on the ground
        else if (moveInput.x != 0) //player moving
        {
            newState=isStanding?"walk right":"Crawl right";
        }
        else //player staying still
        {
            newState=isStanding?"Idle right":"crawl idle";
        }
        if (currentState != newState) //attach the new animation if the state has changed
        {
            animator.Play(newState);
            currentState = newState;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Box")||other.gameObject.CompareTag("Human"))
        {
            isGrounded=true;
            doubleJumped=false; //reset double jump
        }
    }

}