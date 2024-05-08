using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class HealthBar : MonoBehaviour
{
    public UnityEngine.UI.Image healthBar;
    public float healthAmount = 120f;
    public float healthAmountStart = 120;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount-=damage;
        healthBar.fillAmount = healthAmount / healthAmountStart;
    }
}
