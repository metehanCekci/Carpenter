using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicLoader : MonoBehaviour
{
    public AudioSource aR;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.GetComponent<AudioSource>().isPlaying==false)

        aR.gameObject.SetActive(true);

    


        

    
}
}
