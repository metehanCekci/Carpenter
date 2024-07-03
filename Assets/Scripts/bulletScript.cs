using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public bool goingLeft = false;
    public GameObject attackScript;
    public AudioSource audioPlayer;
    public GameObject playerHpScript;


    public playerHpScript phs;
    void Start()
    {
        attackScript = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * speed * Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
     
            phs = other.transform.GetComponent<playerHpScript>();
            if (other.gameObject.layer == 8)
            {
                attackScript.GetComponent<attackScript>().parryable = false;
                phs =other.gameObject.GetComponent<playerHpScript>();
                phs.takeDamage(transform.position);
                Destroy(gameObject);
                

            }         
        }
                else if(other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
