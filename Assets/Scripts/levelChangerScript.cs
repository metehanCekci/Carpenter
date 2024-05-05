using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChangerScript : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    void Update()
    {
        
    }

    public void fadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("fadeOut");
    }
    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
