using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{  
    public GameObject[] enemies;
    public GameObject[] lasers;
    public GameObject heal;

    private float zEnemySpawn = 500.0f;
    private float zHealSpawn = 50.0f;
    private float xSpawnRange = 10.0f;
    private float yUpperSpawnRange = 7.5f;
    private float yBottomSpawnRange = 2.5f;

    private float healSpawnTime = 5.0f;
    private float enemySpawnTime = 6.0f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnHeal", startDelay, healSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn enemies at random positions
    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(yBottomSpawnRange, yUpperSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, randomY, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
    }

    void SpawnHeal()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomY = Random.Range(yBottomSpawnRange, yUpperSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, randomY, zHealSpawn);

        Instantiate(heal, spawnPos, heal.transform.rotation);
    }

    public void SpawnLaser(Vector3 spawnPos, int index)
    {
        Instantiate(lasers[index], spawnPos, lasers[index].transform.rotation);
    }
}
