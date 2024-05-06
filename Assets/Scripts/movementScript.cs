using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{
    public playerHpScript playerHpScript;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Animator animator;
    public GravCheck gravCheck;
    public GameObject levelChanger;
    public GameObject entranceClose;
    public GameObject attackScript;

    private float horizontal;
    public float speed = 3.0f;
    public float jumpingPower = 5f;
    public bool isFacingRight = true;
    private bool cDash = false;
    private bool isDash;
    public float Dashpower = 20f;
    public float DashSpeed = 20f;

    public bool isInverted = false;
    private float dashingTime = 0.2f;
    public float dashingCooldown = 0.5f;

    private Collider2D playerCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerHpScript = GetComponent<playerHpScript>();
        levelChanger = GameObject.FindGameObjectWithTag("levelChanger");
        attackScript = GameObject.FindGameObjectWithTag("Player");


        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isDash)
        {
            return;
        }



        if (rb.velocity.y <= 0)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", true);
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (attackScript.GetComponent<attackScript>().attacking == false)
        {
            if (!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }
        }

        animator.SetBool("onAir", !isGrounded());
        animator.SetBool("onGround", isGrounded());
        animator.SetBool("isWalking", Mathf.Abs(horizontal) > 0f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null && hit.collider.CompareTag("enemy"))
        {
            transform.position = new Vector3(transform.position.x, hit.collider.transform.position.y + 0.5f, transform.position.z);
        }
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

    public void Dash(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            StartCoroutine(Dash());
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fallDetector"))
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentLevelIndex != 7)
            {
                currentLevelIndex++;
                levelChanger.GetComponent<levelChangerScript>().fadeToLevel(currentLevelIndex);
            }
            else
            {
                levelChanger.GetComponent<levelChangerScript>().fadeToLevel(0);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            try
            {
                entranceClose.SetActive(true);
            }
            catch { }
        }
    }

    private IEnumerator Dash()
    {



        if (cDash == false)
        {
            isDash = true;
            cDash = true;
            Physics2D.IgnoreLayerCollision(playerCollider.gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;

            if (isInverted == false)
            {
                // Calculate the target position for dashing
                Vector3 targetPosition = transform.position + new Vector3(1f * transform.localScale.x, 0f, 0f);

                // Perform the dash with physics
                rb.velocity = new Vector2(transform.localScale.x * Dashpower, 0f);

                // Use a RaycastHit2D to check for collisions during the dash
                RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, Vector3.Distance(transform.position, targetPosition), LayerMask.GetMask("ObstacleLayer"));

                if (hit.collider != null)
                {
                    // If the character hits an obstacle during the dash, adjust the target position to the point of collision
                    targetPosition = (Vector3)hit.point - (targetPosition - transform.position).normalized * 0.1f; // Convert hit.point to Vector3
                }

                float timer = 0;
                // Move the character towards the target position
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f && timer < 0.1)
                {
                    Debug.Log(timer);
                    timer += Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, DashSpeed * Time.deltaTime);
                    yield return null;
                }
            }
            else
            {
                // Calculate the target position for dashing
                Vector3 targetPosition = transform.position + new Vector3(1f * transform.localScale.x, 0f, 0f);

                // Perform the dash with physics (negating x component for inverted dash)
                rb.velocity = new Vector2(-transform.localScale.x * Dashpower * 2, 0f);

                // Use a RaycastHit2D to check for collisions during the dash
                RaycastHit2D hit = Physics2D.Raycast(transform.position, targetPosition - transform.position, Vector3.Distance(transform.position, targetPosition), LayerMask.GetMask("ObstacleLayer"));

                if (hit.collider != null)
                {
                    // If the character hits an obstacle during the dash, adjust the target position to the point of collision
                    targetPosition = (Vector3)hit.point - (targetPosition - transform.position).normalized * 0.1f; // Convert hit.point to Vector3
                }
                float timer = 0;
                // Move the character towards the target position
                while (Vector3.Distance(transform.position, targetPosition) > 0.1f && timer < 0.1)
                {
                    Debug.Log(timer);
                    timer += Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, DashSpeed * Time.deltaTime);
                    yield return null;
                }
            }

            yield return new WaitForSeconds(dashingTime);

            Physics2D.IgnoreLayerCollision(playerCollider.gameObject.layer, LayerMask.NameToLayer("Enemy"), false);

            rb.gravityScale = originalGravity;
            isDash = false;

            rb.velocity = new Vector2(0f, rb.velocity.y);

            yield return new WaitForSeconds(dashingCooldown);
            cDash = false;


        }

        Debug.Log("Dash bitti");
    }
}
