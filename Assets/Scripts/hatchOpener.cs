using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class hatchOpener : MonoBehaviour
{
    public GameObject hatch;
    public attackScript aS;
    public bool enable = false;
    public int enemyAmt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (this.gameObject.GetComponent<spawnerScript>().currentIndex > this.gameObject.GetComponent<spawnerScript>().spawnableObjects.Length)
            {
                Debug.Log("metehandebugdedi");

                if (aS.killAmount == enemyAmt)

                {

                    if(enable)
                    StartCoroutine(setActive());
                    else
                    StartCoroutine(openHatch());


                    }


            }
        }
        catch { }

    }

    IEnumerator openHatch()
    {

        yield return new WaitForSeconds(2f);
        Destroy(hatch);

    }

    IEnumerator setActive()
    {

        yield return new WaitForSeconds(2f);
        hatch.SetActive(true);

    }

}
