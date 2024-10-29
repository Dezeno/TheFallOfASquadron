using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveForward : MonoBehaviour
{
    private float speed = 100.0f;
    private float movingLimit = 10.0f;
    private float startDelay = 6.0f;
    private float laserCooldown = 1.5f;


    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
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
        if (transform.position.z > movingLimit)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
    }

    private void EnemyLaser()
    {
        spawnManager.SpawnLaser(transform.position, 1);
    }
}
