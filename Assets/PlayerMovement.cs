using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private Collider2D coll;

    private bool isGrounded;
    private bool canJump;
    private int jumpsRemaining;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (isGrounded)
        {
            canJump = true;
            jumpsRemaining = maxJumps;
        }
        else if (jumpsRemaining <= 0)
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsRemaining--;

        if (jumpsRemaining <= 0)
        {
            canJump = false;
        }
    }
}
