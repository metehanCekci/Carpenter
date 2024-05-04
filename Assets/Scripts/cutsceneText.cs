using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutsceneText : MonoBehaviour
{
    public Text textComponent;
    private string fullText;
    public float delay = 0.1f;
    public bool bittimi = false; // Baþlangýçta false olmalý
    private int textIndex = 0;

    private string currentText = "";

    public string text1;
    public string text2;
    public string text3;
    public string text4;

    void Start()
    {
        // Ýlk metni baþlangýçta göstermek için burada çaðýrabilirsiniz
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
                        // Tüm metinler gösterildiyse burada baþka bir iþlem yapýlabilir
                        break;
                }
                textIndex++; // textIndex'i arttýrýn
                StartCoroutine(ShowText()); // Coroutine'u baþlatýn
            }
        }
    }

    IEnumerator ShowText()
    {
        // Her yeni metin için currentText'i sýfýrlayýn
        currentText = "";
        // Metni teker teker göstermek için bir döngü oluþturun
        foreach (char letter in fullText)
        {
            // Her bir harfi ekleyerek metni teker teker gösterin
            currentText += letter;
            textComponent.text = currentText; // Güncellenmiþ metni Text bileþenine atayýn
            yield return new WaitForSeconds(delay); // Her harf arasýnda bir gecikme saðlayýn
        }
    }
}
