using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
            Debug.Log("Sald�rd�!");
        }
    }
    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
    }
    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit enemy!");
        }
    }
}
