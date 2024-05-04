using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject[] spawnableObjects;
    public float spawnInterval = 1f; // Saniyeler cinsinden

    private float timer = 0f;
    private int currentIndex = 0;

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
            currentIndex = 0;
        }

        GameObject spawnableObject = spawnableObjects[currentIndex];
        GameObject newObject = Instantiate(spawnableObject);
        newObject.transform.position = this.gameObject.transform.position;
        currentIndex++;
    }
}