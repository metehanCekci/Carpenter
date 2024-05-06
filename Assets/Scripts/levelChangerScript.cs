using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChangerScript : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
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
