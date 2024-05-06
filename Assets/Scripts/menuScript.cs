using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    private bool isPaused = false;
    private bool gameCompleted = false;

    public GameObject menu;
    public GameObject player;
    public GameObject ayarlar;
    public GameObject anaMenu;
    public GameObject easterEgg;

    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;

        // Oyun bitirildiyse level seçme ekranýný gizle
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            gameCompleted = PlayerPrefs.GetInt("GameCompleted", 0) == 1;
            if (gameCompleted)
            {
                menu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void eggCikar()
    {
        anaMenu.SetActive(false);
        easterEgg.SetActive(true);
    }

    public void eggKapa()
    {
        anaMenu.SetActive(true);
        easterEgg.SetActive(false);
    }

    public void loadFoundyScene()
    {
        SceneManager.LoadScene("Foundy");
    }

    public void loadChinaTownyScene()
    {
        SceneManager.LoadScene("ChinaTowny");
    }

    public void loadFaciltyScene()
    {
        SceneManager.LoadScene("Facilty");
    }

    public void loadBossFightScene()
    {
        SceneManager.LoadScene("Boss");
    }

    // Oyunu bitirme metodu
    public void FinishGame()
    {
        PlayerPrefs.SetInt("GameCompleted", 1);
    }
}
