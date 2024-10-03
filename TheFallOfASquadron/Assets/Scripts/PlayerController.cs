using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float yUpperBound = 11.0f;
    private float yBottomBound = 3.5f;
    private float xBound = 10.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    // Movements of the player using the WASD keys with the boundaries of the camera
    void PlayerMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) && transform.position.y < yUpperBound)
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > yBottomBound)
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xBound)
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < xBound)
        {
            direction += Vector3.right;
        }

        transform.Translate(direction * Time.deltaTime * speed);
    }
}
