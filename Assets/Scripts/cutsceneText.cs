using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cutsceneText : MonoBehaviour
{
    public Text textComponent;
    public string text1;
    public string text2;
    public string text3;
    private string fullText;
    public float delay = 0.1f;
    private bool bittimi = false; // Ba�lang��ta false olmal�
    private int textIndex = 0;

    void Start()
    {
        Time.timeScale = 1.0f;
        textComponent.text = "Text Component";
        bittimi = false;
        fullText = text1;
        StartCoroutine(ShowText());
    }

    void Update()
    {
        if (bittimi && Input.GetKeyDown(KeyCode.Space)) // Bittimi kontrol� ve Space tu�u kontrol� tek sat�rda
        {
            textIndex++; // textIndex'i artt�r�n
            switch (textIndex)
            {
                case 1:
                    delay = 0.1f;
                    fullText = text2;
                    break;
                case 2:
                    delay = 0.1f;
                    fullText = text3;
                    break;
                default:
                    SceneManager.LoadScene(2); // T�m metinler g�sterildiyse belirtilen sahneye ge�
                    break;
            }
            StartCoroutine(ShowText()); // Coroutine'u ba�lat�n
        }
    }

    IEnumerator ShowText()
    {
        bittimi = false;
        for (int i = 0; i <= fullText.Length; i++)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                delay = 0;
            }
            string currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        bittimi = true;
    }
    
}
