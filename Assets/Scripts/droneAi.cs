using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneAi : MonoBehaviour
{
    public Transform target; // The target GameObject to follow
    public float followSpeed = 5f; // Speed at which the GameObject follows the target
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public bool isBoss;

    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the current position to the target's position
            Vector3 direction = target.position - transform.position;

            // Move towards the target's position
            transform.position += direction.normalized * followSpeed * Time.deltaTime;

            // Flip the sprite horizontally if moving left
            if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            // Flip the sprite horizontally if moving right
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<playerHpScript>().takeDamage(other.transform.position);

        }
    }
        private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<playerHpScript>().takeDamage(other.transform.position);

        }
    }
}
