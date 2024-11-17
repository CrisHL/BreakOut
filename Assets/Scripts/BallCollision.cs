using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            gameManager.DecreaseBlock();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.LoseLife();
    }
}
