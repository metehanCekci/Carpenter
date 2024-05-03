using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyborgAi : MonoBehaviour
{
    public GameObject Player;
    public GameObject hurtBox;
    public Transform target;
    public Animator anim;

    public float attackDelay;
    public float attackDelay2;
    public bool isAwake = false;
    public bool canMove = true;
    public bool attackOnCooldown = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (isAwake)
        {
            if (canMove)
            {
                // Hedefin pozisyonunu al
                Vector3 targetPosition = target.position;

                // Yalnızca x ekseni boyunca takip etmek için y ve z pozisyonlarını sabit tut
                targetPosition.y = transform.position.y;
                targetPosition.z = transform.position.z;

                if (target.position.x < transform.position.x)
                {
                    // Hedef soldaysa sola dön
                    transform.rotation = Quaternion.Euler(0, 180, 0); // Karakteri 180 derece döndürür (sola)
                }
                else
                {
                    // Hedef sağdaysa sağa dön
                    transform.rotation = Quaternion.Euler(0, 0, 0); // Karakteri orijinal dönüşüne geri getirir (sağa)
                }

                // Takip eden GameObject'in pozisyonunu yavaşça hedefin pozisyonuna doğru güncelle
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            }

        }
    }

    public void Attack()
    {
        if (attackOnCooldown == false)
        {
            attackOnCooldown = true;
            StartCoroutine(IEnuAttack());
        }


    }

    IEnumerator IEnuAttack()
    {
        canMove = false;
        yield return new WaitForSeconds(attackDelay);
        hurtBox.SetActive(true);
        Debug.Log("hit");
        yield return new WaitForSeconds(0.1f);
        hurtBox.SetActive(false);
        yield return new WaitForSeconds(attackDelay2);
        attackOnCooldown = false;
        canMove = true;

    }
}