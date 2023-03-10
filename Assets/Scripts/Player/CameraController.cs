using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player; // Public variable to store a which player object will be used
    private Vector3 offset; // Private variable to store the offset distance between the player and camera

    // Start() is called before the first frame update, or when the game is launched and loaded
    void Start() 
    {
        // Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate() is called after Update() each frame
    private void LateUpdate() 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}