using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravCheck : MonoBehaviour
{
    [HideInInspector] public bool GravChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GravCollider"))
        {

            StartCoroutine(GravChange());
        }

    }

    IEnumerator GravChange()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1f;
        yield return new WaitForSeconds(.5f);
        if (!GravChanged)
        {
            transform.rotation = Quaternion.Euler(180f, 180f, 0f);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        GravChanged = !GravChanged;
    }
}
