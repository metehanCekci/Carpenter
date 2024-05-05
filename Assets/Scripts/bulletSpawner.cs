using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBullet()
    {

        GameObject clone = Instantiate(bullet);
        clone.SetActive(true);
        clone.transform.position = transform.position;
        Destroy(clone,5);

    }
}
