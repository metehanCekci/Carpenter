using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
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
}
