using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

// The main PlayerController for receiving inputs from the user and applying it to the player
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update, or when the game is launched and loaded
    void Start()
    {
        // Assign the player character Rigidbody as a variable to be referenced when the Vector 2 attributes of the Rigidbody2D are retrieved
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Player Controller Started");
    }

    // Called when a input is received in Unity by a keyboard or controller
    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        Debug.Log(movementVector);
        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log("Moving");
    }

    
    private void Update() 
    {
        Vector2 movement = new Vector2(movementX, movementY); // The Vector3 constructor was using the wrong order of arguments
        rb.AddForce(movement);
    }
}