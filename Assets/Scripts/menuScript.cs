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
    public GameObject player;
    public GameObject ayarlar;
    public GameObject anaMenu;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void escape()
    {
        if (isPaused)
        {
            resume();
            player.GetComponent<attackScript>().SetGamePaused(false);
        }
        else
        {
            pause();
            player.GetComponent<attackScript>().SetGamePaused(true);
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
        ayarlar.SetActive(true);
        anaMenu.SetActive(false);
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
    public void ayarCikis()
    {
        ayarlar.SetActive(false);
        anaMenu.SetActive(true);
    }

}
