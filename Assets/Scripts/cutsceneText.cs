using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneText : MonoBehaviour
{
    public Text textComponent;
    private string fullText;
    public float delay = 0.1f;
    public bool bittimi = false; // Ba�lang��ta false olmal�
    private int textIndex = 0;

    private string currentText = "";

    public string text1;
    public string text2;
    public string text3;
    public string text4;

    void Start()
    {
        // �lk metni ba�lang��ta g�stermek i�in burada �a��rabilirsiniz
    }

    void Update()
    {
        if (bittimi)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // GetKey yerine GetKeyDown kullanmal�s�n�z
            {
                // Metinler aras�nda ge�i� yapmak i�in textIndex'i kontrol edin
                switch (textIndex)
                {
                    case 0:
                        fullText = text1;
                        break;
                    case 1:
                        fullText = text2;
                        break;
                    case 2:
                        fullText = text3;
                        break;
                    case 3:
                        fullText = text4;
                        break;
                    default:
                        // T�m metinler g�sterildiyse burada ba�ka bir i�lem yap�labilir
                        break;
                }
                textIndex++; // textIndex'i artt�r�n
                StartCoroutine(ShowText()); // Coroutine'u ba�lat�n
            }
        }
    }

    IEnumerator ShowText()
    {
        // Her yeni metin i�in currentText'i s�f�rlay�n
        currentText = "";
        // Metni teker teker g�stermek i�in bir d�ng� olu�turun
        foreach (char letter in fullText)
        {
            // Her bir harfi ekleyerek metni teker teker g�sterin
            currentText += letter;
            textComponent.text = currentText; // G�ncellenmi� metni Text bile�enine atay�n
            yield return new WaitForSeconds(delay); // Her harf aras�nda bir gecikme sa�lay�n
        }
    }
}
