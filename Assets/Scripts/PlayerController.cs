using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    BallScript ball;
    public bool autoPlay;
    public bool faster;
    public bool playerInputEnabled;

    public AudioClip PickupLife;
    public AudioClip PickupPower;
    public AudioClip PickupEnergy;
    public AudioClip PowerDown;
    public AudioClip AsteroidBump;

    public bool energyBarInScene;

    bool NewSceneLoaded = true;

    void Start()
    {
        playerInputEnabled = true;

        ball = GameObject.FindObjectOfType<BallScript>();

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blocks)
        {
            if (faster)
            {
                LevelManager.instance.LaadVolgendLevel();
                faster = false;
            }
        }

        if (GameObject.FindGameObjectWithTag("EnergyBar"))
        {
            energyBarInScene = true;
        }
        else
        {
            energyBarInScene = false;
        }

        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Score : " + LevelManager.instance.score;
        GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>().text = "Hull integrity : " + LevelManager.instance.lives;
    }

    void Update()
    {
        if (playerInputEnabled)
        {
            if (autoPlay == false)
            {
                Vector3 cursorPositie = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(cursorPositie.x, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(ball.transform.position.x, transform.position.y);
            }
        }

        if (energyBarInScene && playerInputEnabled == true)
        {
            GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount = ((GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount * 2000) - 1) / 2000;

            if (GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount == 0)
            {
                GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<PauseScript>().OutOfEnergy();
                gameObject.GetComponent<AudioSource>().clip = PowerDown;
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            switch (collision.transform.name)
            {
                case "PickupPower":
                    GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>().PullBeamRemaining = 100;
                    GameObject.FindGameObjectWithTag("PullBar").GetComponent<Image>().fillAmount = 100;
                    gameObject.GetComponent<AudioSource>().clip = PickupPower;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                    Destroy(collision.gameObject);
                    break;
                case "PickupLife":
                    LevelManager.instance.LivesUp();
                    gameObject.GetComponent<AudioSource>().clip = PickupLife;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                    Destroy(collision.gameObject);
                    break;
                case "PickupEnergy":
                    GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount = 100;
                    gameObject.GetComponent<AudioSource>().clip = PickupEnergy;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                    Destroy(collision.gameObject);
                    break;
            }
        }

        if (collision.gameObject.tag == "Block")
        {
            LevelManager.instance.LivesDown();
            gameObject.GetComponent<AudioSource>().clip = AsteroidBump;
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            Destroy(collision.gameObject);
        }
    }
}
