using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;

    bool gamePaused = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!gamePaused && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
        }
    }
    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
    }
    public void attack()
    {
        Debug.Log("sald�rd�!");
        if (!gamePaused)
        {
            Debug.Log("oyun ak�yor!");
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
            foreach (Collider2D enemyGameObject in enemy)
            {
                Debug.Log("du�man bulundu");
                Debug.Log("Hit enemy!");
                enemyGameObject.GetComponent<enemyHealth>().health -= damage;
                if (enemyGameObject.GetComponent<enemyHealth>().health <= 0)
                {
                    Debug.Log("oldu");
                    Destroy(enemyGameObject.gameObject);
                }
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    public void SetGamePaused(bool paused)
    {
        gamePaused = paused;
    }
}
