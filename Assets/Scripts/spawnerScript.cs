using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnableObjects;
    [SerializeField]
    public float spawnInterval = 1.0f; // Saniyeler cinsinden


    private float timer = 0f;
    public int currentIndex = 0;

    private void Update()
    {

        

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnNextObject();
            timer = 0f;
        }
    }


    private void SpawnNextObject()
    {
        if (currentIndex >= spawnableObjects.Length)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else{

        GameObject spawnableObject = spawnableObjects[currentIndex];
        GameObject newObject = Instantiate(spawnableObject);
        newObject.transform.position = this.gameObject.transform.position;
        newObject.SetActive(true);
        
        }

        currentIndex++;
    }
}
