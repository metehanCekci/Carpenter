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
    public GameObject exclama2;
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
        yield return new WaitForSeconds(4);
        randomizeAttack();
        StartCoroutine(startAttack());

    }

    public void randomizeAttack()
    {

        int randomNumber = Random.Range(1, 7);

        if(randomNumber == 1) lazerAttack();
        else if(randomNumber == 2) StartCoroutine(mermiAttack());
        else if (randomNumber == 3) StartCoroutine(dikenAttack());
        else if (randomNumber == 4) StartCoroutine(sawAttack());
        else if (randomNumber == 5) followingBullet();

        
    }

    public void lazerAttack()
    {

        GameObject clone = Instantiate(lazerGroup);
        clone.SetActive(true);

    }

    IEnumerator mermiAttack()
    {
        exclama2.SetActive(true);
        yield return new WaitForSeconds(2);
        exclama2.SetActive(false);
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
        yield return new WaitForSeconds(10);
        spike1.SetActive(false);
        spike2.SetActive(false);

    }

    IEnumerator sawAttack()
    {
        exclamaBottom.SetActive(true);
        yield return new WaitForSeconds(2);
        exclamaBottom.SetActive(false);

        saw.SetActive(true);
        yield return new WaitForSeconds(14);
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

    public void destroyAll()
    {
        Destroy(spike1);
        Destroy(spike2);
        Destroy(exclama);
        Destroy(exclamaBottom);
        Destroy(followPlayer);
        Destroy(saw);
        Destroy(lazerGroup);
        Destroy(bulletSpawner);
        Destroy(bulletSpawner2);
    }

    
}
