using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// The main PlayerController for receiving inputs from the user and applying it to the player
public class PlayerController : MonoBehaviour
{
    public GameObject StartLocation;
    public float jumpStrength = 1000;
    public float speed = 800;
    public int jumpLimit = 2;
    public float deathVoid = -75;

    private Rigidbody2D rb;
    private Vector2 startLocationPosition;
    private PlayerInput playerInput;
    //private PlayerControls playerControls;
    private bool isJumping = false;
    private bool isMoving = false;
    private bool isGrounded = true;
    private int jumps = 0;
    private float movementX;
    private float movementY;

    // Store our control actions as variables to be reused
    private InputAction moveAction;
    private InputAction jumpAction;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Here the control actions are set and 
    /// <summary>
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        playerInput.actions.Enable();
        moveAction.started += context => OnMove(context);
        jumpAction.started += context => OnJump(context);
    }

    /// <summary>
    /// This function is called when the object becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        playerInput.actions.Disable();
        moveAction.started -= context => OnMove(context);
        jumpAction.started -= context => OnJump(context);
    }
    
    /// <summary>
    /// Start is called before the first frame update, or when the game is launched and loaded
    /// <summary>
    public void Start()
    {
        // Assign the player character Rigidbody as a variable to be referenced when the Vector 2 attributes of the Rigidbody2D are retrieved
        rb = GetComponent<Rigidbody2D>();
        Vector2 startLocationPosition = new Vector2(StartLocation.transform.position.x, StartLocation.transform.position.y);
        Debug.Log(startLocationPosition);
        rb.MovePosition(startLocationPosition);
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.Sleep();
    }

    /// <summary>
    /// Called when the player character is touching a GameObject with a Box Collider2d
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            jumps = 0;
            isGrounded = true;
        }
    }

    /// <summary>
    /// Called when the assigned Move control is pressed
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        if (movementVector.x > 0 || movementVector.x < 0)
        {
            Debug.Log("MOVING");
            movementX = movementVector.x * speed;
            Debug.Log($"movementX: {movementX}");
            rb.AddForce(new Vector2(movementX, 0.0f));
            isMoving = true;
        }
        
        if (movementVector.x == 0)
        {
            Debug.Log("STOPPED MOVING");
            //movementX = movementVector.x * 0;
            //Vector2 movement = new Vector2(movementX, 0.0f);
            if (isGrounded)
            {   
                Vector2 vel = rb.velocity;
                vel.x = 0.0f;
                rb.velocity = vel;
                isMoving = false;
            }
        }
    }

    /// <summary>
    /// Called when the assigned Jump control is pressed
    /// </summary>
    /// <param name="context"></param>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            Debug.Log(jumps);
            Debug.Log(jumpLimit);
            jumpStrength = jumpStrength * context.ReadValue<float>();
            Debug.Log(jumpStrength);
            Vector2 jumpMovement = new Vector2(0.0f, jumpStrength);

            if (jumps >= jumpLimit)
            {
                Debug.Log("Hit jumpLimit");
                return;
            }

            rb.AddForce(jumpMovement);
            jumps += 1;
            Debug.Log("JUMPING");
        }
    }

    /// <summary>
    /// Function to handle respawning when hitting the deathVoid limit
    /// </summary>
    /// <returns></returns>
    private IEnumerator Respawn()
    {   
        rb.velocity = new Vector2(0.0f, 0.0f);
        Debug.Log(startLocationPosition);
        rb.MovePosition(startLocationPosition);
        rb.Sleep();
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(0.0f, 2.0f);
    }

    /// <summary>
    /// Update is called every game frame
    /// </summary>
    private void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "DeathVoid")
        {
            Debug.Log("Hit Death Void");
            StartCoroutine(Respawn());
        }
    }
}