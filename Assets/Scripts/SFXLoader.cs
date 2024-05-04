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
        Debug.Log("hasar verme sesi calisti");
        aS.PlayOneShot(hit);
    }

    public void playHurt()
    {
        Debug.Log("hasar alma sesi calisti");
        aS.PlayOneShot(hurt);
    }

    public void playCyborgShoot()
    {
        Debug.Log("sayborg ates etti");
        aS.PlayOneShot(cyborgShoot);
    }


}
