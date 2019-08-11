using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject LoseScreen;
    public GameObject OutOfEnergyScreen;
    public GameObject WinScreen;
    public GameObject player;
    GameObject level;

    float timer = 0.8f;

    bool deathAudioPlayed = false;

    public void Start()
    {
        Menu.SetActive(false);
        LoseScreen.SetActive(false);
        WinScreen.SetActive(false);
        if (OutOfEnergyScreen)
        {
            OutOfEnergyScreen.SetActive(false);
        }
        Time.timeScale = 1;

        player = GameObject.FindGameObjectWithTag("Player");
        level = GameObject.FindGameObjectWithTag("Level");

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !WinScreen.active && !LoseScreen.active || Input.GetKey(KeyCode.Escape) && !OutOfEnergyScreen.active && !WinScreen.active && !LoseScreen.active )
        {
            Time.timeScale = 0;
            InputEnabled(false);
            Menu.SetActive(true);
        }

        if (LevelManager.instance.lives <= 0)
        {
            InputEnabled(false);

            GameObject.FindGameObjectWithTag("DeathAnim").GetComponent<Animator>().SetBool("HasDied", true);
            GameObject.FindGameObjectWithTag("DeathAnim2").GetComponent<Animator>().SetBool("HasDied", true);

            if (player.GetComponentInChildren<SpriteRenderer>().enabled)
            {
                player.GetComponentInChildren<SpriteRenderer>().enabled = !player.GetComponentInChildren<SpriteRenderer>().enabled;
                GameObject.FindGameObjectWithTag("ShipSprite").GetComponent<SpriteRenderer>().enabled = false;
            }

            if (deathAudioPlayed == false)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                deathAudioPlayed = true;
            }

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject.FindGameObjectWithTag("DeathAnim").active = false;
                GameObject.FindGameObjectWithTag("DeathAnim2").active = false;
                Time.timeScale = 0;
                LoseScreen.SetActive(true);
            }
        }

        if (GameObject.FindGameObjectWithTag("Level").transform.transform.position.y <= -125 && SceneManager.GetActiveScene().name != "lvl2")
        {
            Time.timeScale = 0;
            InputEnabled(false);
            WinScreen.SetActive(true);
        }
        else if(GameObject.FindGameObjectWithTag("Level").transform.transform.position.y <= -125 && SceneManager.GetActiveScene().name == "lvl2")
        {
            Time.timeScale = 0;
            InputEnabled(false);
            LevelManager.instance.GetComponent<MenuScript>().LoadIntermission2();
        }
    }

    public void OutOfEnergy()
    {
        OutOfEnergyScreen.SetActive(true);
        InputEnabled(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Menu.SetActive(false);
        InputEnabled(true);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        LevelManager.instance.lives = 3;
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void mainMenu()
    {
        LevelManager.instance.levelNumber = 1;
        if(LevelManager.instance.InfiniLives == true)
        {
            LevelManager.instance.lives = 9999999;
        }
        else
        {
            LevelManager.instance.lives = 3;
        }
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public void InputEnabled(bool value)
    {
        player.GetComponent<PlayerController>().playerInputEnabled = value;
        level.GetComponent<LevelSlidingScript>().playerInputEnabled = value;
        Cursor.visible = !value;
    }
}