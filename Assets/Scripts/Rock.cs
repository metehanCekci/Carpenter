using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject pointC;
    public GameObject pointD;
    public float speed = 1;
    public bool movingDownwards = true;

    void Start()
    {
        StartCoroutine(DelayHide());
    }

    void Update()
    {
        if (movingDownwards)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pointD.transform.position.x, transform.position.y - 0.071f, pointD.transform.position.z), speed * Time.deltaTime);
            if (transform.position.y <= -0.071f) movingDownwards = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointC.transform.position, speed * Time.deltaTime);
            if (transform.position.y >= pointC.transform.position.y) movingDownwards = true;
        }
    }

    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerHpScript>().takeDamage(other.transform.position);
        }
    }
}
