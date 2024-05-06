using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravCheck : MonoBehaviour
{
    [HideInInspector] public bool GravChanged = false;
    public movementScript mv;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GravChange(collision));
        }

    }

    IEnumerator GravChange(Collider2D collision)
    {
        
        collision.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1f;
        yield return new WaitForSeconds(0);
        mv.isInverted = !mv.isInverted;
        
        if (!GravChanged)
        {
            collision.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            collision.transform.position = new Vector2(collision.transform.position.x , collision.transform.position.y / 2);
            if(!mv.isFacingRight)
            mv.Flip();
        }
        else
        {
            collision.transform.position = new Vector2(collision.transform.position.x , collision.transform.position.y / 2);
            
            collision.transform.rotation = Quaternion.Euler(0, 0, 0);
            if(mv.isFacingRight)
            mv.Flip();
        }
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        collision.transform.localScale = localScale;
        GravChanged = !GravChanged;
    }
}
