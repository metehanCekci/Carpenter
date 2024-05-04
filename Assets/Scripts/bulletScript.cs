using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public bool goingLeft = false;

    public AudioSource audioPlayer;


    public playerHpScript phs;
    void Start()
    {

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
            if (other.gameObject.layer == 8)
            {

                phs.takeDamage(transform.position);
                Destroy(gameObject);

            }

        }
    }
}
