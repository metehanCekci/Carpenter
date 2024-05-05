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
    public GameObject levelChanger;
    public GameObject entranceClose;

    private float horizontal;
    public float speed = 3.0f;
    public float jumpingPower = 5f;
    public bool isFacingRight = true;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        levelChanger = GameObject.FindGameObjectWithTag("levelChanger");
        

    }

    // Update is called once per frame
    void Update()
    {

        if (rb.velocity.y <= 0)
        {
            //A�a�� yonlu hareket
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


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null && hit.collider.CompareTag("enemy"))
        {
            // Karakterin y�ksekli�ini ayarlayarak d��man�n i�inden ge�mesini sa�lay�n
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fallDetector"))
        {
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            
            if (currentLevelIndex!=6)
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
            try{
            entranceClose.SetActive(true);
            }
            catch{}
        }
    }

}
