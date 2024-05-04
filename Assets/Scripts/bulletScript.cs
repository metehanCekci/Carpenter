using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public bool goingLeft = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position += transform.right * speed * Time.deltaTime;
        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //club penguin is kill
    }
}
