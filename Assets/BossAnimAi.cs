using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimAi : MonoBehaviour
{
    public Animator BossAnim;
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
        yield return new WaitForSeconds(5);
        BossAnim.SetBool("isRising" , false);

    }
}
