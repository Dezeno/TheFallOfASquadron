using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserMovement : MonoBehaviour
{
    public float speed = -20.0f;
    public float zBound = -10.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.z < zBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.isGameActive)
        {
            Destroy(gameObject);
            if(gameManager.playerHealth > 10)
            {
                gameManager.UpdateHealth(-10);
            }
            else
            {
                gameManager.UpdateHealth(-gameManager.playerHealth);
            }
            if (gameManager.playerHealth <= 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
