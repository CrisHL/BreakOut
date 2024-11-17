using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject paddle;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject gameOver;

    private Vector3 initialPaddlePosition;
    private Vector3 initialBallPosition;

    public int lives = 3;
    int blockLeft;

    void Start()
    {
        blockLeft = GameObject.FindGameObjectsWithTag("Block").Length;
        Debug.Log(blockLeft);

        if (paddle != null)
            initialPaddlePosition = paddle.transform.position;

        if (ball != null)
            initialBallPosition = ball.transform.position;

        if (gameOver != null)
            gameOver.SetActive(false);
    }

    public void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    public void DecreaseBlock()
    {
        blockLeft--;
        Debug.Log("Quedan " + blockLeft + " bloques ");
        if (blockLeft == 0)
        {
            LoadNextScene();
        }
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Vidas restantes: " + lives);

        if (lives > 0)
        {
            Debug.Log("Reiniciando posiciones...");
            ResetPositions();
            GameObject ballObject = GameObject.Find("ball");
            if (ballObject != null)
            {
                ballObject.GetComponent<BallMovement>().ResetBall();
            }
        }
        else
        {
            GameOver();
        }
    }

    void ResetPositions()
    {
        if (paddle != null)
        {
            paddle.transform.position = initialPaddlePosition;
            Debug.Log("Paddle reiniciado a: " + initialPaddlePosition);
        }

        if (ball != null)
        {
            ball.transform.position = initialBallPosition;
            Debug.Log("Pelota reiniciada a: " + initialBallPosition);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOver != null)
        {
            gameOver.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
