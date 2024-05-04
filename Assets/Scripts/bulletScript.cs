using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public bool goingLeft = false;
    public float knockbackForce = 999;
    public Rigidbody2D rb;
    public AudioSource audioPlayer;

    public Vector2 direction;
    public Vector2 knockback;
    public playerHpScript phs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position += transform.right * speed * Time.deltaTime;
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.layer == 8)
            {
                
                Debug.Log("hit");
                audioPlayer.Play();
                // Calculate knockback direction
                Vector2 direction = (transform.position - other.transform.position).normalized;
            // Apply knockback force
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            phs.HP--;
            phs.iFramesFunc();
            }
            Destroy(this.gameObject);
            
        }
        
    }
}
