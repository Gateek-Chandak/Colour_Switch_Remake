using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleManager : MonoBehaviour
{
    public GameObject lifeOrb;
    public bool orbIsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 5);

        if (x == 1)
        {
            orbIsSpawned = true;
            lifeOrb.SetActive(true);
        }
        else
        {
            orbIsSpawned = false;
            lifeOrb.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

   
}
