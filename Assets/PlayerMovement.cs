using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2; // set to 2 for double jump
    public PhysicsMaterial2D slipperyMaterial;
    public PhysicsMaterial2D stickyMaterial;
    private Rigidbody2D rb;
    private int jumpsRemaining;
    private Collider2D playerCollider;
    private bool isCollidingWithPlatform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        playerCollider = GetComponent<Collider2D>();
        playerCollider.sharedMaterial = stickyMaterial; // start with sticky material
    }

    // Update is called once per frame
    void Update()
    {
        // Move left or right
        float horizontalInput = Input.GetAxis("Horizontal");

        // Disable horizontal movement if colliding with platform
        if (isCollidingWithPlatform)
        {
            horizontalInput = 0f;
        }

        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;

            // Play jump sound or animation
        }
    }

    // Check for collision with ground to reset jumps and adjust friction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
            playerCollider.sharedMaterial = slipperyMaterial; // switch to slippery material
        }
        else if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Wall"))
        {
            playerCollider.isTrigger = true; // disable collider to prevent sticking
            isCollidingWithPlatform = true;
        }
    }

    // Check for leaving ground or platform to switch back to sticky material
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerCollider.sharedMaterial = stickyMaterial; // switch back to sticky material
        }
        else if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Wall"))
        {
            playerCollider.isTrigger = false; // re-enable collider
            isCollidingWithPlatform = false;
        }
    }
}
