using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLoader : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip hit;
    public AudioClip hurt;
    public AudioClip cyborgShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playHit()
    {
        aS.PlayOneShot(hit);
    }

    public void playHurt()
    {
        aS.PlayOneShot(hurt);
    }

    public void playCyborgShoot()
    {
        aS.PlayOneShot(cyborgShoot);
    }


}
