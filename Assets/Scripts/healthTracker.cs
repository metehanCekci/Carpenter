using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthTracker : MonoBehaviour
{
    public Sprite hp10;
    public Sprite hp9;
    public Sprite hp8;
    public Sprite hp7;
    public Sprite hp6;
    public Sprite hp5;
    public Sprite hp4;
    public Sprite hp3;
    public Sprite hp2;
    public Sprite hp1;
    public Sprite hp0;
    public playerHpScript phs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(phs.HP == 10)
        this.gameObject.GetComponent<Image>().sprite = hp10;

        if(phs.HP == 9)
        this.gameObject.GetComponent<Image>().sprite = hp9;

        if(phs.HP == 8)
        this.gameObject.GetComponent<Image>().sprite = hp8;

        if(phs.HP == 7)
        this.gameObject.GetComponent<Image>().sprite = hp7;

        if(phs.HP == 6)
        this.gameObject.GetComponent<Image>().sprite = hp6;

        if(phs.HP == 5)
        this.gameObject.GetComponent<Image>().sprite = hp5;

        if(phs.HP == 4)
        this.gameObject.GetComponent<Image>().sprite = hp4;

        if(phs.HP == 3)
        this.gameObject.GetComponent<Image>().sprite = hp3;

        if(phs.HP == 2)
        this.gameObject.GetComponent<Image>().sprite = hp2;

        if(phs.HP == 1)
        this.gameObject.GetComponent<Image>().sprite = hp1;
        if(phs.HP == 0)
        this.gameObject.GetComponent<Image>().sprite = hp0;
    }
}
