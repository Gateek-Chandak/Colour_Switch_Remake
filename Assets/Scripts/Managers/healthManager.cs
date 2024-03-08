using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public static int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addLife()
    {
        lives++;
    }

    public void loseLife()
    {
        lives--;
    }
}
