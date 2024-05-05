using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public GameObject lazerGroup;
    public bulletSpawner bulletSpawner;
    public bulletSpawner bulletSpawner2;
    public GameObject spike1;
    public GameObject spike2;
    public GameObject exclama;
    public GameObject exclamaBottom;
    public GameObject homingExclama;

    public GameObject followPlayer;
    public GameObject saw;
    public GameObject source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFight()
    {
        StartCoroutine(startAttack());
    }

    IEnumerator startAttack()
    {
        yield return new WaitForSeconds(5);
        randomizeAttack();
        StartCoroutine(startAttack());

    }

    public void randomizeAttack()
    {

        int randomNumber = Random.Range(1, 7);

        if(randomNumber == 1) lazerAttack();
        else if(randomNumber == 2 || randomNumber == 3) StartCoroutine(mermiAttack());
        else if (randomNumber == 4) StartCoroutine(dikenAttack());
        else if (randomNumber == 5) StartCoroutine(sawAttack());
        else if (randomNumber == 6) followingBullet();

        
    }

    public void lazerAttack()
    {

        GameObject clone = Instantiate(lazerGroup);
        clone.SetActive(true);

    }

    IEnumerator mermiAttack()
    {

        bulletSpawner.spawnBullet();
        bulletSpawner2.spawnBullet();
        yield return new WaitForSeconds(1);
        bulletSpawner.spawnBullet();
        bulletSpawner2.spawnBullet();
        yield return new WaitForSeconds(1);
        bulletSpawner.spawnBullet();
        bulletSpawner2.spawnBullet();
        yield return new WaitForSeconds(1);
        bulletSpawner.spawnBullet();
        bulletSpawner2.spawnBullet();
        yield return new WaitForSeconds(1);

    }

    IEnumerator dikenAttack()
    {
        exclama.SetActive(true);
        yield return new WaitForSeconds(2);
        exclama.SetActive(false);
        spike1.SetActive(true);
        spike2.SetActive(true);
        yield return new WaitForSeconds(15);

    }

    IEnumerator sawAttack()
    {

        saw.SetActive(true);
        yield return new WaitForSeconds(10);
        saw.SetActive(false);

    }

    IEnumerator horizontalLazer()
    {

        yield return new WaitForSeconds(1);
        

    }

    public void followingBullet()
    {

        
        GameObject clone = Instantiate(followPlayer);
        clone.SetActive(true);
        clone.transform.position = source.transform.position;

    }

    
}
