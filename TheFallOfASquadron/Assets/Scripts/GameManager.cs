using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float xSpawnRange = 5.0f;
    private float ySpawn = 2.0f;

    public List<GameObject> enemies;
    private float enemySpawnRate;
    private float zEnemySpawn = 500.0f;

    public List<GameObject> lasers;

    public GameObject heal;
    private float healSpawnRate = 5.0f;
    private float zHealSpawn = 50.0f;

    public TextMeshProUGUI healthText;
    public int playerHealth;

    public TextMeshProUGUI gameOverText;
    public bool isGameActive;

    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        playerHealth = 100;
        enemySpawnRate = Random.Range(1.0f, 5.0f);
        StartCoroutine(SpawnRandomEnemy());
        StartCoroutine(SpawnHeal());
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRandomEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(enemySpawnRate);

            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Count);
            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
        }
    }

    IEnumerator SpawnHeal()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(healSpawnRate);

            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            Vector3 spawnPos = new Vector3(randomX, ySpawn, zHealSpawn);

            Instantiate(heal, spawnPos, heal.transform.rotation);
        }
    }
    public void SpawnLaser(Vector3 spawnPos, int index)
    {
        if (isGameActive)
        {
            Instantiate(lasers[index], spawnPos, lasers[index].transform.rotation);
        }
    }

    public void UpdateHealth(int healthToAdd)
    {
        playerHealth += healthToAdd;
        healthText.text = "Health : " + playerHealth;
        if (playerHealth <= 20)
        {
            healthText.color = Color.red;
        }
        else
        {
            healthText.color = Color.white;
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
