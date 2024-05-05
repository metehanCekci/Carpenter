using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTrigger : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;

    public GameObject spawner5;

    public GameObject spawner6;

    public GameObject spawner7;

    public GameObject spawner8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            try { spawner1.SetActive(true); }
            catch { }
            try { spawner2.SetActive(true); }
            catch { }
            try { spawner3.SetActive(true); }
            catch { }
            try { spawner4.SetActive(true); }
            catch { }
            try { spawner5.SetActive(true); }
            catch { }
            try { spawner6.SetActive(true); }
            catch { }
            try { spawner7.SetActive(true); }
            catch { }
            try { spawner8.SetActive(true); }
            catch { }

            Destroy(this.gameObject);
        }
    }
}
