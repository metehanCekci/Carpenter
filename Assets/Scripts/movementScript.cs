using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Animator animator;

    private float horizontal;
    public float speed=3.0f;
    public float jumpingPower = 5f;
    public bool isFacingRight = true;

    public float shortJumpForce = 10f; // Kýsa zýplama kuvveti
    public float longJumpForce = 20f; // Uzun zýplama kuvveti
    public float maxJumpTime = 0.5f; // Maksimum zýplama süresi
    public float jumpTime = 0f; // Geçerli zýplama süresi
    private bool isJumping = false; // Zýplama durumu

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
        animator.SetBool(name: "onAir", value: !isGrounded());
        animator.SetBool(name: "isWalking", value: Mathf.Abs(horizontal) > 0f);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpTime = 0f;
            Jump(shortJumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTime < maxJumpTime)
            {
                jumpTime += Time.deltaTime;
                // Zýplama süresine göre zýplama mesafesini artýr
                float jumpForce = Mathf.Lerp(shortJumpForce, longJumpForce, jumpTime / maxJumpTime);
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            isJumping = false;
        }
    }
    void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        isFacingRight=!isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
