using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public Animator anim;
    public GameObject attackPoint;
    public playerHpScript playerHpScript;
    public GameObject cyborgAi;
    public enemyFacing eF;
    public int killAmount = 0;
    public float radius;
    public float knockbackAmt;
    public SFXLoader sFX;
    public LayerMask enemies;
    public float damage;
    public CameraShake CS;
    public GameObject kan;

    public bool parryable = false;
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
                sFX.playHit();
                CS.ShakeIt();

                Vector2 knockback;
                if (enemyGameObject.gameObject.CompareTag("Boss"))
                {

                }
                else
                {
                    if (enemyGameObject.GetComponent<enemyFacing>().facingRight)
                    {
                        enemyGameObject.GetComponent<Rigidbody2D>().AddForce(knockback = new Vector2(knockbackAmt * -1, 2.0f), ForceMode2D.Impulse);
                    }
                    else
                    {
                        enemyGameObject.GetComponent<Rigidbody2D>().AddForce(knockback = new Vector2(knockbackAmt, 2.0f), ForceMode2D.Impulse);
                    }
                }
                enemyGameObject.GetComponent<enemyHealth>().health -= damage;
                if (enemyGameObject.GetComponent<enemyHealth>().health <= 0)
                {
                    killAmount++;
                    GameObject clone = Instantiate(kan);
                    clone.transform.position = enemyGameObject.transform.position;
                    clone.SetActive(true);
                    Destroy(enemyGameObject.gameObject);
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
    public void SetGamePaused(bool pauseCondition)
    {
        gamePaused = pauseCondition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("weapon"))
        {
            Debug.Log("silah algilandi");
            if (parryable)
            {
                Debug.Log("Parrylenebilir");
                beklet();
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    Debug.Log("parry calisti");
                    playerHpScript.GetComponent<playerHpScript>().takeNoDamage = true;
                    cyborgAi.GetComponent<cyborgAi>().enabled = false;
                    beklet();
                    playerHpScript.GetComponent<playerHpScript>().takeNoDamage = false;
                    cyborgAi.GetComponent<cyborgAi>().enabled = true;
                }
            }

        }
    }
    IEnumerator beklet()
    {
        yield return new WaitForSeconds(120);
    }
}
