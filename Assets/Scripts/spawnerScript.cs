using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public bool isOver = false;
    [SerializeField]
    public GameObject[] spawnableObjects;
    [SerializeField]
    public float spawnInterval = 0.5f; // Saniyeler cinsinden

    private float timer = 0f;
    private int currentIndex = 0;

    private void Update()
    {
        if (isOver == false)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnNextObject();
                timer = 0f;
            }
        }
    }


    private void SpawnNextObject()
    {
        if (currentIndex >= spawnableObjects.Length)
        {
            isOver = true;
        }

        GameObject spawnableObject = spawnableObjects[currentIndex];
        GameObject newObject = Instantiate(spawnableObject);
        newObject.transform.position = this.gameObject.transform.position;
        newObject.SetActive(true);
        currentIndex++;
    }
}
