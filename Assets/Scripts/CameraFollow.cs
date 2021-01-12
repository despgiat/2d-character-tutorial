using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing = 5f; //The camera damping
    Vector3 offset; //We need to calculate an offset for the camera's position so to alter it's position correctly relative to the player
    //as we don't want it to "stick" into the player character.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //We find the gameObject in the scene with the tag "Player"
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offset = new Vector3(0f, 0f, transform.position.z - player.transform.position.z); //Distance on the z axis between the camera and the player
        
        Vector3 playerPosition = player.transform.position + offset;
        Vector3 newPosition = Vector3.Lerp(transform.position, playerPosition, smoothing * Time.deltaTime); //Linear Interpolation between the camera's position and the player's position by the interpolant smoothing
        //Lerp, or Linear Interpolation, is a mathematical function in Unity that returns a value between two others at a point on a linear scale.
        //It’s used for moving or changing values over a period of time.

        transform.position = newPosition; //The camera moves to the player's position
    }
}
