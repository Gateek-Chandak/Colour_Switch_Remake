using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{
    public Text scoreText;
    public Text gmText; //game over text
    public Text psText; //press space to restart text
    public Text beginText;  //press space to begin text
    public Text highScore;
    public Text lifeText;

    public GameObject player;

    public float waitTime;
    public int score;

    void Start()
    {
        score = 0;

        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        gmText.enabled = false;
        psText.enabled = false;
        beginText.enabled = true;
    }


    void Update()
    {
        scoreText.text = " " + score;
        lifeText.text = "lives: " + healthManager.lives;

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
      
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && pauseMenu.isPaused == false)
        {
            beginText.enabled = false;
        }

        if (player == null)
        {
            StartCoroutine(waitFor());
        }
    }

    public void reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
    }

    IEnumerator waitFor()
    {
        gmText.enabled = true;
        yield return new WaitForSeconds(1f);
        psText.enabled = true;
    }
}
