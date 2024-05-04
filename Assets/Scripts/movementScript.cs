using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Animator animator;
    public GravCheck gravCheck;

    private float horizontal;
    public float speed = 3.0f;
    public float jumpingPower = 5f;
    public bool isFacingRight = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y < 0)
        {
            //Aþaðý yonlu hareket
            animator.SetBool(name: "isFalling", value: true);
            animator.SetBool(name: "isJumping", value: false);
        }
        else
        {
            animator.SetBool(name: "isFalling", value: false);
            animator.SetBool(name: "isJumping", value: true);
        }

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
        animator.SetBool(name: "onGround", value: isGrounded());
        animator.SetBool(name: "isWalking", value: Mathf.Abs(horizontal) > 0f);

    }

    public void Menu()
    {

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded())
        {
            if (gravCheck.GravChanged)
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower * -1);
            else
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
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="fallDetector")
        {
            if (SceneManager.GetActiveScene().buildIndex==1)
            {

            }
        }
    }


}
