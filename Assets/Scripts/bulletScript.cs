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
            Debug.Log("parry calisti");
            attackScript.GetComponent<attackScript>().parryable = true;
            phs = other.transform.GetComponent<playerHpScript>();
            if (other.gameObject.layer == 8)
            {
                phs=other.gameObject.GetComponent<playerHpScript>();
                phs.takeDamage(transform.position);
                Destroy(gameObject);

            }
            beklet();
            attackScript.GetComponent<attackScript>().parryable = false;

        }
    }
    IEnumerator beklet()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("parry bekletildi");
    }
}
