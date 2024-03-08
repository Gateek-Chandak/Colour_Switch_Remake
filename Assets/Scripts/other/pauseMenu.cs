using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused;

    public GameObject resumeText;
    public GameObject slider;
    public GameObject sliderText;
    public GameObject restartText;
    public GameObject psText;
    public GameObject gameOver;
    public GameObject beginText;

    public GameObject bg;

    public AudioMixer audioMixer;

    public AudioSource pauseSound;
    public AudioSource clickSound;
    public AudioSource mainSound;

    void Start()
    {
        resumeText.SetActive(false);
        slider.SetActive(false);
        sliderText.SetActive(false);
        restartText.SetActive(false);
        bg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        { 
            if(isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1f;
        isPaused = false;

        gameOver.SetActive(true);
        psText.SetActive(true);
        beginText.SetActive(true);

        resumeText.SetActive(false);
        slider.SetActive(false);
        sliderText.SetActive(false);
        restartText.SetActive(false);
        bg.SetActive(false);

        pauseSound.Play();
   }

    void pause()
    {
        Time.timeScale = 0f;
        isPaused = true;

        gameOver.SetActive(false);
        psText.SetActive(false);
        beginText.SetActive(false);

        resumeText.SetActive(true);
        slider.SetActive(true);
        sliderText.SetActive(true);
        restartText.SetActive(true);
        bg.SetActive(true);

        pauseSound.Play();
    }

    public void click()
    {
        Time.timeScale = 1f;
        isPaused = false;

        gameOver.SetActive(true);
        psText.SetActive(true);
        beginText.SetActive(true);

        resumeText.SetActive(false);
        slider.SetActive(false);
        sliderText.SetActive(false);
        restartText.SetActive(false);
        bg.SetActive(false);

        clickSound.Play();
    }


    public void volumeControl(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
