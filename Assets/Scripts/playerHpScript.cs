using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class playerHpScript : MonoBehaviour
{
    public int maxHP = 10;
    public int HP = 10;
    public float IFrameDuration = 0.5f;
    public GameObject died;

    // Start is called before the first frame update
    void Start()
    {
        died.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP<=0)
        {
            Time.timeScale = 0.0f;
            died.SetActive(true);
        }
    }

    IEnumerator IFrames()
    {

        this.gameObject.layer = 9;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(IFrameDuration);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        this.gameObject.layer = 8;

    }
    
    public void iFramesFunc()
    {
        StartCoroutine(IFrames());
    }
    
    
}
