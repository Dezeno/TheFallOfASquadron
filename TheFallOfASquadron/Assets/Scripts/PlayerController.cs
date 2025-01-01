using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float xBound = 5.0f;
    
    private GameManager gameManager;

    public float laserCooldown = 0.5f;
    private float lastLaserTime = -Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerLaser();
    }

    // Movements of the player using the WASD keys with the boundaries of the camera
    void PlayerMovement()
    {
        Vector3 direction = Vector3.zero;

        if (gameManager.isGameActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -xBound)
            {
                direction += Vector3.left;
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < xBound)
            {
                direction += Vector3.right;
            }

            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    private void PlayerLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastLaserTime + laserCooldown && gameManager.isGameActive)
        {
            gameManager.SpawnLaser(transform.position, 0);
            lastLaserTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal") && gameManager.isGameActive)
        {
            Destroy(other.gameObject);
            if(gameManager.playerHealth < 75)
            {
                gameManager.UpdateHealth(25);
            }
            else
            {
                gameManager.UpdateHealth(100 - gameManager.playerHealth);
            }
            
        }
    }
}
