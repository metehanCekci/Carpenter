using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimAi : MonoBehaviour
{
    public Animator BossAnim;
    public BossAi bAi;
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

        BossAnim.SetBool("isRising" , true);
        yield return new WaitForSeconds(9);
        BossAnim.SetBool("isRising" , false);
        bAi.startFight();


    }
}
