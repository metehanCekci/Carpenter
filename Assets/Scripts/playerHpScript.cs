using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class playerHpScript : MonoBehaviour
{
    public int maxHP = 10;
    public int HP = 10;
    public SFXLoader sfx;
    public float IFrameDuration = 0.5f;
    public GameObject died;
    public Rigidbody2D rb;

    public bool takeNoDamage = false;
    public float knockbackForce = 999;
    public Vector2 direction;
    public Vector2 knockback;

    // Start is called before the first frame update
    void Start()
    {
        died.SetActive(false);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Time.timeScale = 0.0f;
            died.SetActive(true);
        }
    }

    IEnumerator IFrames()
    {

        this.gameObject.layer = 9;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(IFrameDuration);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        this.gameObject.layer = 8;

    }

    public void takeDamage(Vector2 bulletPosition)
    {
        if (this.gameObject.layer == 8 && takeNoDamage==false)
        {
            sfx.playHurt();
            try
            {
                Vector3 bulletPosition3D = new Vector3(bulletPosition.x, bulletPosition.y);
                // Calculate knockback direction
                Vector2 direction = ((Vector2)transform.position - bulletPosition).normalized;
                // Apply knockback force
                rb.AddForce(direction * knockbackForce, ForceMode2D.Force);
            }

            catch { }
            HP--;
            StartCoroutine(IFrames());

        }
    }
}



