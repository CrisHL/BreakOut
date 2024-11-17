using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    float bounds = 7.54f;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float newPositionX = transform.position.x + speed * xInput * Time.deltaTime;

        if (newPositionX < bounds && newPositionX > -bounds)
        {
            transform.position += new Vector3(speed * xInput * Time.deltaTime, 0f, 0f);
        }
    }
}
