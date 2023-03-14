using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Speed at which the enemy moves
    public Transform leftEdge; // The left edge of the enemy's movement area
    public Transform rightEdge; // The right edge of the enemy's movement area
    public Transform playerSpawn; // The spawn point for the player

    private bool movingRight = true; // Whether the enemy is currently moving to the right

    void Update()
    {
        // Check if the enemy has reached the left or right edge of its movement area
        if (transform.position.x <= leftEdge.position.x)
        {
            movingRight = true;
        }
        else if (transform.position.x >= rightEdge.position.x)
        {
            movingRight = false;
        }

        // Move the enemy left or right depending on its current direction
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    // Check for collision with the player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teleport the player back to the spawn point
            collision.gameObject.transform.position = playerSpawn.position;
        }
    }
}
