using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bekletici : MonoBehaviour
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
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelIndex != 7)
        {
            currentLevelIndex++;
            levelChanger.GetComponent<levelChangerScript>().fadeToLevel(currentLevelIndex);
        }
        else
        {
            //levelChanger.GetComponent<levelChangerScript>().fadeToLevel(0);
        }
    }
}
