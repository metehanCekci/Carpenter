using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SFXLoader : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip hit;
    public AudioClip hurt;
    public AudioClip cyborgShoot;

    public AudioClip dash;
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

    public void playDash()
    {
        aS.PlayOneShot(dash);
    }


}
