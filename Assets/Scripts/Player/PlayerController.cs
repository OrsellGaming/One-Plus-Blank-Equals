using UnityEngine;
using UnityEngine.InputSystem;

// The main PlayerController for receiving inputs from the user and applying it to the player
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isJumping;
    private bool isMoving;
    private int jumps;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update, or when the game is launched and loaded
    public void Start()
    {
        // Assign the player character Rigidbody as a variable to be referenced when the Vector 2 attributes of the Rigidbody2D are retrieved
        rb = GetComponent<Rigidbody2D>();
        float movementX = rb.position.x;
        float movementY = rb.position.y;
        Debug.Log("Player Controller Started");
    }

    // Called when a input is received in Unity by a keyboard or controller
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        Debug.Log("Moving");
        movementX = movementVector.x;
        movementY = movementVector.y;
        Vector2 movement = new Vector2(movementX, movementY);
        Debug.Log(movement);
        rb.AddForce(movement);
    }

    // public void OnMove(InputValue movementValue)
    // {
    //     if
    // }
}