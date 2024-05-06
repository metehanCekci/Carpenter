using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public Text textComponent;
    public string fullText;
    public float delay = 0.1f;
    public bool bittimi;

    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(ShowText());
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
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        bittimi= true;
    }
}
