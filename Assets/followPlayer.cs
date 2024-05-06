using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform target; // Reference to the target (character) to follow
    public float speed = 5f; // Speed of the bullet
    public playerHpScript phs;

    void Awake()
    {

        Destroy(this.gameObject , 10);

    }

    void Update()
    {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            phs.takeDamage(other.transform.position);
            
        }
    }
}
