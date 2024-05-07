using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class menuScript : MonoBehaviour
{
    private bool isPaused = false;
    private bool bittimi = false;
    //amo
    public GameObject menu;
    public GameObject player;
    public GameObject ayarlar;
    public GameObject anaMenu;
    public GameObject easterEgg;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            player = GameObject.FindGameObjectWithTag("Player");
        }
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
    public void StartZor()
    {
        SceneManager.LoadScene("StartZor");
    }
    public void loadFaciltyScene()
    {
        SceneManager.LoadScene("Facilty");
    }
    public void loadBossFightScene()
    {
        SceneManager.LoadScene("Boss");
    }
    public void SkipCongrats()
    {
        SceneManager.LoadScene("Credits");
    }
    

    public void SetBittimiTrue()
    {
        bittimi = true;
        SceneManager.LoadScene("Start");
    }
    public void Oyna1BtnClicked()
    {
        button6.SetActive(false);
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene("Start");
            Debug.Log("sjdahfuý");
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene("Foundy");
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene("ChinaTowny");
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene("Facilty");
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            SceneManager.LoadScene("Boss");
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }
    public void restart()
    {


        PlayerPrefs.SetInt("level2", 0);

        PlayerPrefs.SetInt("level3", 0);

        PlayerPrefs.SetInt("level4", 0);

        PlayerPrefs.SetInt("level5", 0);

        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);

    }

}
