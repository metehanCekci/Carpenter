using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBarScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 1;
    public bool directionLeft = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (directionLeft == false)
            transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (directionLeft) directionLeft = false;
            else directionLeft = true;
        }
        else if(other.gameObject.CompareTag("Player"))
        {

            other.GetComponent<playerHpScript>().takeDamage(other.transform.position);

        }
    }


}
