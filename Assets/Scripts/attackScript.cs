using System.Collections;
using UnityEngine;

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

    
    public float parryDuration = 1.0f;
    private bool parryActive = false;

    void Start()
    {
        levelChanger = GameObject.FindGameObjectWithTag("levelChanger");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*
        if (!gamePaused && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttacking", true);
            attacking = true;
        }

        if (!gamePaused && Input.GetMouseButtonDown(1) && parryable && !parryActive)
        {
            Debug.Log("Naber");
            StartCoroutine(Parry()); //a
        }
        */
    }


    IEnumerator Parry()
    {
        Debug.Log("Parry ba�lad�");

        
        playerHpScript.takeNoDamage = true;
        parryActive = true;
        yield return new WaitForSeconds(parryDuration);   
        playerHpScript.takeNoDamage = false;
        parryActive = false;

        Debug.Log("Parry bitti");
    }

    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
        attacking = false;
    }

    public void attackInput()
    {
                if (!gamePaused)
                {
                    anim.SetBool("isAttacking", true);
                    attacking = true;
                }
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
                    try
                    {
                        enemyGameObject.GetComponent<BossAnimAi>().TakeDamage();
                        if (enemyGameObject.gameObject.GetComponent<enemyHealth>().health <= 0)
                        {
                            enemyGameObject.gameObject.GetComponent<BossAnimAi>().BossAnim.SetBool("isDead", true);
                            enemyGameObject.gameObject.GetComponent<BossAi>().destroyAll();
                            StartCoroutine(changeScene());
                        }
                    }
                    catch { }

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
        PlayerPrefs.SetInt("isGameFinished",1);
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
                StartCoroutine(Parry());
            }
        }
    }

    IEnumerator beklet()
    {
        yield return new WaitForSeconds(120);
    }
}
