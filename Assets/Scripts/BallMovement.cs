using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Vector2 launchForce;
    bool isBallLaunched;
    Transform paddleTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleTransform = GameObject.Find("paddle").transform;
        ResetBall();
    }

    void Update()
    {
        if (Input.GetButtonDown("Launch") && !isBallLaunched)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        isBallLaunched = true;
        rb.isKinematic = false;
        rb.AddForce(launchForce);
        transform.parent = null;
    }

    // Método para reiniciar la pelota
    public void ResetBall()
    {
        float paddleHeight = paddleTransform.GetComponent<Collider2D>().bounds.size.y;
        float ballHeight = GetComponent<Collider2D>().bounds.size.y;

        transform.position = new Vector3(paddleTransform.position.x, paddleTransform.position.y + paddleHeight / 2f + ballHeight / 2f, 0f);

        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        isBallLaunched = false;
        transform.parent = paddleTransform;
    }


}
