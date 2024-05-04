using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageAmt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) 
    {

        if(other.gameObject.CompareTag("Player"))
        {

            //player take damage
            Debug.Log("hit");

        }
        
    }
}
