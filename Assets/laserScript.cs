using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public float speed;
    public playerHpScript phs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            phs.takeDamage(other.transform.position);
            Destroy(this.gameObject);
        }
        
    }
}
