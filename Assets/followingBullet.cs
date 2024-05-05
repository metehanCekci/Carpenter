using UnityEngine;

public class followingBullet : MonoBehaviour
{
    public Transform target; // Reference to the target (character) to follow
    public float speed = 5f; // Speed of the bullet
    public playerHpScript phs;
    public Vector2 targetPosition;

    private void Awake() {

    
        targetPosition = target.position;
    
    }

    void Update()
    {
        
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if ((Vector2)transform.position == targetPosition)
            {
            Destroy(gameObject);
            }
            

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            phs.takeDamage(other.transform.position);
            Destroy(this.gameObject);
        }
        
    }
}
