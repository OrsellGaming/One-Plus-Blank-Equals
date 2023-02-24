using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

// The main PlayerController for receiving inputs from the user and applying it to the character
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update, or when the game is launched and loaded
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Assign the player character Rigidbody as a variable to be referenced when 
    }

    // Called when a input is received in Unity by a keyboard or controller
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Method name should start with uppercase "G"

        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log(movementX);
        Debug.Log(movementY);
        Debug.Log("Moving");
    }

    
    private void FixedUpdate() 
    {
        Vector2 movement = new Vector2(movementX, movementY); // The Vector3 constructor was using the wrong order of arguments
        rb.AddForce(movement);
        Debug.Log(movement);
    }
}
