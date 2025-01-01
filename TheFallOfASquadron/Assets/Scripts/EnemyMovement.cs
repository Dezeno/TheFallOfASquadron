using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 100.0f;
    private float movingLimit = 20.0f;
    private float startDelay = 6.0f;
    private float laserCooldown = 1.5f;

    public int health;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("EnemyLaser", startDelay, laserCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyApproach();
    }

    // Makes the enemy fly towards the player and stops once it's close enough
    void EnemyApproach()
    {
        if (transform.position.z > movingLimit && gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        if(!gameManager.isGameActive)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyLaser()
    {
        gameManager.SpawnLaser(transform.position, 1);
    }
}
