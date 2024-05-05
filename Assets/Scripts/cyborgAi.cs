using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cyborgAi : MonoBehaviour
{
    public GameObject Player;
    public GameObject hurtBox;
    public GameObject attackScript;
    public Transform target;
    public Animator anim;
    public enemyFacing eF;

    public float attackDelay;
    public float attackDelay2;
    public float knockbackForce;
    public Vector2 knockback;
    public Vector2 direction;
    public bool isAttack = true;
    public bool isAwake = false;
    public bool canMove = true;
    public bool inverted = false;

    public bool ranged;
    public bool attackOnCooldown = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.back*Time.deltaTime * 1);
        attackScript = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (isAwake)
        {
            if (canMove)
            {

                anim.SetBool("isRunning" , true);
                // Hedefin pozisyonunu al
                Vector3 targetPosition = target.position;

                // Yalnızca x ekseni boyunca takip etmek için y ve z pozisyonlarını sabit tut
               
                 targetPosition.y = transform.position.y;
                 targetPosition.z = transform.position.z;
               

                

                // Takip eden GameObject'in pozisyonunu yavaşça hedefin pozisyonuna doğru güncelle
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            }
            else
            {

                anim.SetBool("isRunning" , false);

            }

            if (target.position.x < transform.position.x)
                {
                    
                    if(inverted) {transform.rotation = Quaternion.Euler(180, 180, 0);}
                    // Hedef soldaysa sola dön
                    
                    else {transform.rotation = Quaternion.Euler(0, 180, 0);}  // Karakteri 180 derece döndürür (sola)
                    eF.facingRight = false;
                }
                else
                {
                    
                    if(inverted) transform.rotation = Quaternion.Euler(180, 0, 0);
                    // Hedef soldaysa sola dön
                    else transform.rotation = Quaternion.Euler(0, 0, 0); // Karakteri 180 derece döndürür (sola)
                    eF.facingRight = true;
                }

        }
    }

    public void Attack()
    {
        if (attackOnCooldown == false)
        {
            if(isAttack)
            attackOnCooldown = true;
            anim.SetBool("isAttacking", true);
            if(ranged==false)
            StartCoroutine(IEnuAttack());
            else
            StartCoroutine(IEnuRanged());
        }


    }

    IEnumerator IEnuAttack()
    {
        canMove = false;
        yield return new WaitForSeconds(attackDelay);
        hurtBox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hurtBox.SetActive(false);
        yield return new WaitForSeconds(attackDelay2);
        attackOnCooldown = false;
        anim.SetBool("isAttacking", false);
        canMove = true;

    }

    IEnumerator IEnuRanged()
    {

        canMove = false;
        yield return new WaitForSeconds(attackDelay);
        GameObject clone = Instantiate(hurtBox);
        clone.transform.position = hurtBox.transform.position;
        if(target.position.x > transform.position.x)
        {
            clone.transform.rotation = Quaternion.Euler(0, 0, 0); // Karakteri orijinal dönüşüne geri getirir (sağa)
        }
        else
        {
            clone.transform.rotation = Quaternion.Euler(0, 180, 0); // Karakteri orijinal dönüşüne geri getirir (sağa)
        }
        clone.SetActive(true);
        Destroy(clone , 5);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(attackDelay2);
        attackOnCooldown = false;
        anim.SetBool("isAttacking", false);
        canMove = true;

    }
    

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            if(collision.gameObject.layer == 8)
            {
                attackScript.GetComponent<attackScript>().parryable = true;

                Vector2 playerPosition = new Vector2(collision.transform.position.x, collision.transform.position.y);
                collision.gameObject.GetComponent<playerHpScript>().takeDamage(playerPosition);
                beklet();
            }
            attackScript.GetComponent<attackScript>().parryable = false;

        }
    }
    IEnumerator beklet()
    {
        yield return new WaitForSeconds(120);
        
    }

    
}
