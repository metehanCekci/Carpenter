using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attackScript : MonoBehaviour
{
    public Animator anim;
    public GameObject attackPoint;
    public playerHpScript playerHpScript;
    public GameObject cyborgAi;
    public GameObject levelChanger;
    public enemyFacing eF;
    public int killAmount = 0;
    public float radius;
    public float knockbackAmt;
    public SFXLoader sFX;
    public LayerMask enemies;
    public float damage;
    public CameraShake CS;
    public GameObject kan;
    public HealthBar hb;

    public bool parryable = false;
    bool gamePaused = false;
    public bool attacking;
    void Start()
    {
        levelChanger = GameObject.FindGameObjectWithTag("levelChanger");
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!gamePaused && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
            attacking = true;
        }
    }
    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
        attacking=false;
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
                    try
                    {
                        hb.TakeDamage(damage);
                    }
                catch { }

                Vector2 knockback;
                if (enemyGameObject.gameObject.CompareTag("Boss"))
                {
                    try{enemyGameObject.GetComponent<BossAnimAi>().TakeDamage();
                    if(enemyGameObject.gameObject.GetComponent<enemyHealth>().health <= 0)
                    {
                        
                        enemyGameObject.gameObject.GetComponent<BossAnimAi>().BossAnim.SetBool("isDead", true);
                        StartCoroutine(changeScene());
                    }}
                    catch{}
                    
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

    IEnumerator changeScene()
    {

        yield return new WaitForSeconds(3);
        levelChanger.GetComponent<levelChangerScript>().fadeToLevel(7);

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
