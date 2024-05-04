using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    Animator anim;
    public GameObject attackPoint;
    public enemyFacing eF;
    public float radius;
    public float knockbackAmt;
    public SFXLoader sFX;
    public LayerMask enemies;
    public float damage;
    public CameraShake CS;

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
        if (!gamePaused)
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
            foreach (Collider2D enemyGameObject in enemy)
            {
               /* sFX.playHit();
                CS.ShakeIt();
                Vector2 knockback;
                if(eF.facingRight)
                enemyGameObject.GetComponent<Rigidbody2D>().AddForce(knockback = new Vector2(knockbackAmt* -1, 2.0f) , ForceMode2D.Impulse);
                else
                enemyGameObject.GetComponent<Rigidbody2D>().AddForce(knockback = new Vector2(knockbackAmt , 2.0f) , ForceMode2D.Impulse);
                */
                enemyGameObject.GetComponent<enemyHealth>().health -= damage;
                if (enemyGameObject.GetComponent<enemyHealth>().health <= 0)
                {
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
