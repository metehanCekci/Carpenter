using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public GameObject lazerGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomizeAttack()
    {}

    public void lazerAttack()
    {

        lazerGroup.SetActive(true);

    }
}
