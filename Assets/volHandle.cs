using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class menuVolHandle : MonoBehaviour
{

    public AudioMixer mixer;
    string[] mixnames = new string[3] { "Master", "Muzik", "Efektler" };
    public bool egg = false;

    // Start is called before the first frame update
    void Start()
    {

        if (mixer != null)
            foreach (string name in mixnames)
            {
                float savedValue = PlayerPrefs.GetFloat(name, 100f);
                mixer.SetFloat(name, Mathf.Log(savedValue));
                Debug.Log("Volume Set");
            }
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
