using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMovement : MonoBehaviour
{
    private float speed = 10.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);

            if (transform.position.z < -10)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
