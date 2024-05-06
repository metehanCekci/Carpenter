using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayerPrefs : MonoBehaviour
{
    public string playerPref;
    // Start is called before the first frame update
    void Start()
    {
                PlayerPrefs.SetInt(playerPref,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
