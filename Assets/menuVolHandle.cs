using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class menuVolHandle : MonoBehaviour
{

    public AudioMixer mixer;
    string[] mixnames = new string[3] { "Master", "Muzik", "Efektler" };

    
    // Start is called before the first frame update
    void Start()
    {
        
        if (mixer != null)
            foreach(string name in mixnames)
            {
                float savedValue = PlayerPrefs.GetFloat(name);
                mixer.SetFloat(name, Mathf.Log(savedValue) * 20f);
                Debug.Log("Volume Set");
            }
        Destroy(gameObject);
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
