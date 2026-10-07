using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpImpulse = 5.0f;

    Rigidbody2D rb;
    float moveX;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = moveX * moveSpeed;
    }

    void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    void OnJump()
    {
        if (isGrounded)
            rb.AddForceY(jumpImpulse, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
