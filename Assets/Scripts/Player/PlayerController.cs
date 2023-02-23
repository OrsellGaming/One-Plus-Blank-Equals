using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
