using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class menuScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject menu;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex==1) 
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
       
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void escape()
    {
        if (isPaused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }
    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    public void settings()
    {

    }
    public void resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        menu.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        menu.SetActive(true);
    }

}
