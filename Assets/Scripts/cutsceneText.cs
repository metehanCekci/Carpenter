using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class cutsceneText : MonoBehaviour
{
    public Text textComponent;
    public string fullText;
    public float delay = 0.1f;
    public bool bittimi = false; // Baþlangýçta false olmalý
    private int textIndex = 0;

    private string currentText = "";

    public string text1;
    public string text2;
    public string text3;

    void Start()
    {
        
        Time.timeScale = 1.0f;
        textIndex++;
        textComponent.text = "Text Component";
        bittimi = false;
        fullText = text1;
        
        StartCoroutine(ShowText());
    }

    void Update()
    {
        if (bittimi)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // GetKey yerine GetKeyDown kullanmalýsýnýz
            {
                // Metinler arasýnda geçiþ yapmak için textIndex'i kontrol edin
                switch (textIndex)
                {
                    case 0:
                        delay = 0.1f;
                        fullText = text1;
                        break;
                    case 1:
                        delay = 0.1f;
                        fullText = text2;
                        break;
                    case 2:
                        delay = 0.1f;
                        fullText = text3;
                        break;
                    default:
                        // Tüm metinler gösterildiyse burada baþka bir iþlem yapýlabilir
                        break;
                }
                textIndex++; // textIndex'i arttýrýn
                StartCoroutine(ShowText()); // Coroutine'u baþlatýn
            }
            if (currentText == text3)
            {
                    SceneManager.LoadScene(2);
            }
        }
        else
        {
            bekle();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                delay = 0;
            }
        }
    }

    IEnumerator ShowText()
    {
        bittimi = false;
        for (int i = 0; i <= fullText.Length; i++)
        {         
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        bittimi = true;
    }
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(2);
    }
}
