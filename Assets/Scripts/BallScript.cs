using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    PlayerController player;
    bool started = false;
    public bool endGame;
    AudioSource audiosource;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        LevelManager levenmanager = GameObject.FindObjectOfType<LevelManager>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!started)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1f);
        }

        if (Input.GetMouseButtonDown(0) && started == false)
        {
            started = true;
            Vector2 speed = new Vector2(1f, 7f);
            GetComponent<Rigidbody2D>().velocity = speed;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel("menu");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audiosource.Play();
        if (endGame == true)
        {
            if (collision.transform.name == "Border-bottom")
            {
                Debug.Log("fuck");
                SceneManager.LoadScene("lose");
            }
        }
    }
}
