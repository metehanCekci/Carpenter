using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitCredits : MonoBehaviour
{
    public GameObject levelChanger;
    // Start is called before the first frame update
    void Start()
    {
        levelChanger = GameObject.FindGameObjectWithTag("levelChanger");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void creditsCikis()
    {
        levelChanger.GetComponent<levelChangerScript>().fadeToLevel(0);
    }
}
