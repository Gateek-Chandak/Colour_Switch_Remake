using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCircle : MonoBehaviour
{
    public int numOfOb;
    
    public GameObject player;
    public List<GameObject> gameobjects = new List<GameObject>();

    public GameObject overlap;
    public GameObject startPos;


    void Start()
    {
       int y = Random.Range(0, numOfOb);
       Instantiate(gameobjects[y], startPos.transform.position, Quaternion.identity);
    }


    void Update()
    {
 
    }
    public void spawn()
    {
        int x = Random.Range(0, numOfOb);
        Instantiate(gameobjects[x], overlap.transform.position, Quaternion.identity);
    }

}
