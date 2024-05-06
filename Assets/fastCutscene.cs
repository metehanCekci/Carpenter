using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastCutscene : MonoBehaviour
{
    bool holdingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key is being pressed");
            holdingDown = true;
            Time.timeScale = 3.0f;
        }

        if (!Input.anyKey && holdingDown)
        {
            Debug.Log("A key was released");
            holdingDown = false;
            Time.timeScale = 1.0f;
        }

    }
}
