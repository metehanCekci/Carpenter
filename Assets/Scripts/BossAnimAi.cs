using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimAi : MonoBehaviour
{
    public Animator BossAnim;
    public BossAi bAi;
    public GameObject Audio;

    public GameObject g1;
    public GameObject g2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {

        StartCoroutine(TakeHit());

    }

    IEnumerator TakeHit()
    {

        BossAnim.SetBool("isDamaged", true);
        yield return new WaitForSeconds(0.2f);
        BossAnim.SetBool("isDamaged", false);

    }

    public void StartIdle()
    {

        

    }
    public void StartRise()
    {

        StartCoroutine(StartRiseIEnu());

    }

    IEnumerator StartRiseIEnu()
    {
        g1.SetActive(true);
        g2.SetActive(true);
        BossAnim.SetBool("isRising" , true);
                Audio.SetActive(true);
        yield return new WaitForSeconds(4);
        bAi.startFight();
        yield return new WaitForSeconds(5);
        BossAnim.SetBool("isRising" , false);

        


    }
}
