using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        if (player == null)
        {
            StartCoroutine(newScene());
        }
    }

    IEnumerator newScene()
    {
        yield return new WaitForSeconds(1f);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void onClickNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
