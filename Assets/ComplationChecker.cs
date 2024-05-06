using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplationChecker : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    // Start is called before the first frame update
    void Start()
    {

        button1.SetActive(true);
        if(PlayerPrefs.GetInt("level2")==1)
        button2.SetActive(true);
        if(PlayerPrefs.GetInt("level3")==1)
        button3.SetActive(true);
        if(PlayerPrefs.GetInt("level4")==1)
        button4.SetActive(true);
        if(PlayerPrefs.GetInt("level5")==1)
        button5.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
