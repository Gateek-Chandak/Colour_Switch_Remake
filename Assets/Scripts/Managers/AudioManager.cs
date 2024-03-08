using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameObject player;

    public AudioSource mainAudio;
    public GameObject deathAudio;

    void Start()
    {
        mainAudio.Play();
        deathAudio.SetActive(false);
    }

    
    void Update()
    {
        if (player == null)
        {
            mainAudio.Pause();
            deathAudio.SetActive(true);
        }
    }
}
