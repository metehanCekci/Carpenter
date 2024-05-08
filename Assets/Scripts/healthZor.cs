using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthZor : MonoBehaviour
{
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
    public GameObject attackScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (phs.HP == 8)
            this.gameObject.GetComponent<Image>().sprite = hp8;

        if (phs.HP == 7)
            this.gameObject.GetComponent<Image>().sprite = hp7;

        if (phs.HP == 6)
            this.gameObject.GetComponent<Image>().sprite = hp6;

        if (phs.HP == 5)
            this.gameObject.GetComponent<Image>().sprite = hp5;

        if (phs.HP == 4)
            this.gameObject.GetComponent<Image>().sprite = hp4;

        if (phs.HP == 3)
            this.gameObject.GetComponent<Image>().sprite = hp3;

        if (phs.HP == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = hp2;
            attackScript.gameObject.GetComponent<attackScript>().damage = 2;
            attackScript.gameObject.GetComponent<attackScript>().anim.SetBool("lowHp", true);
        }

        if (phs.HP == 1)
            this.gameObject.GetComponent<Image>().sprite = hp1;

        if (phs.HP == 0)
            this.gameObject.GetComponent<Image>().sprite = hp0;
    }
}
