using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRiseScript : MonoBehaviour
{
    public shakeObject sO;
    public BossAnimAi bA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        bA.gameObject.SetActive(true);
        sO.ShakeIt();
        bA.StartRise();
        Destroy(this.gameObject);
    }
}
