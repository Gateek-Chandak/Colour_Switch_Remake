using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerManager : MonoBehaviour
{
    [Header("VARIABLES")]
    public float jumpForce;
    public int lives;
    public float loseLifeWaitTime = 1f;

    [Header("REFERENCES")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;

    public GameObject mainCamera;
   
    [Header("SCRIPT REFERENCES")]
    public spawnCircle spawn;
    public textManager score;
    public CameraShake cameraShake;
    public CameraShake orbCamShake;
    public healthManager hm;

    [Header("AUDIO EFFECT")]
    public AudioSource ding;
    public AudioSource lifeOrb;
    public AudioSource loseLife;

    [Header("DEATH EFFECTS")]
    public GameObject starExplosion;
    public GameObject destroyEffect;
    public GameObject lifeOrbExplosion;

    [Header("COLORS")]
    public string currentColor;

    public Color cyan;
    public Color yellow;
    public Color magenta;
    public Color pink;

    //--------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        setRandomColor();

        rb.gravityScale = 0;

        spawn = spawn.GetComponent<spawnCircle>();
        hm = hm.GetComponent<healthManager>();

        lives = 1;
   }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.gravityScale = 3;
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    //ON COLLISION----------------------------------------------------------------------------------------
    void OnTriggerEnter2D(Collider2D col)
    {
        //colour changer
        if (col.tag == "colourChanger")
        {
            setRandomColor();
            Destroy(col.gameObject);
            return;
        }

        //wrong color
        if (col.tag != currentColor && col.tag != "star" && col.tag != "lifeOrb" && col.tag != "spawn" && lives <= 1)
        {
            hm.loseLife();
            Instantiate(destroyEffect, transform.position, Quaternion.identity, mainCamera.transform);
            cameraShake.ShakeIt();
            Destroy(this.gameObject);
        }
        if (col.tag != currentColor && col.tag != "star" && col.tag != "lifeOrb" && col.tag != "spawn" && lives >= 2)
        { 
            StartCoroutine(loseLifeShake());
        }
        //score
        if (col.tag == "star")
        {
            Instantiate(starExplosion, transform.position, Quaternion.identity, mainCamera.transform);
            ding.Play();
            Destroy(col.gameObject);
            score.score++;
        }

        //health
        if(col.tag == "lifeOrb")
        {
            lifeOrb.Play();
            Instantiate(lifeOrbExplosion, transform.position, Quaternion.identity, mainCamera.transform);
            hm.addLife();
            lives++;
            Destroy(col.gameObject);
        }

        //bottom
        if (col.tag == "bottom")
        {
            cameraShake.ShakeIt();
            Destroy(this.gameObject);
        }

		if (col.tag == "spawn")
		{
			spawn.spawn();
			Destroy(col.gameObject);
		}
	}

    //FUNCTIONS-----------------------------------------------------------------------------------------------

    void setRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:  
                if(currentColor == "cyan")
                {
                    setRandomColor();
                }
                currentColor = "cyan";
                sr.color = cyan;
                break;

            case 1:
                if (currentColor == "yellow")
                {
                    setRandomColor();
                }
                currentColor = "yellow";
                sr.color = yellow;
                break;

            case 2:
                if (currentColor == "magenta")
                {
                    setRandomColor();
                }
                currentColor = "magenta";
                sr.color = magenta;
                break;

            case 3:
                if (currentColor == "pink")
                {
                    setRandomColor();
                }
                currentColor = "pink";
                sr.color = pink;
                break;
        }
    }

    IEnumerator loseLifeShake()
    {
        anim.SetBool("lostLife", true);
		this.GetComponent<CircleCollider2D>().enabled = false;
        orbCamShake.ShakeIt();
        hm.loseLife();
        lives--;
        loseLife.Play();
        yield return new WaitForSeconds(loseLifeWaitTime);
        anim.SetBool("lostLife", false);
        this.GetComponent<CircleCollider2D>().enabled = true;
    }
}
