using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    BallScript ball;
    public bool autoPlay;
    public bool faster;

    public int blocksRemaining;

    void Start()
    {
        ball = GameObject.FindObjectOfType<BallScript>();

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject block in blocks)
        {
            if (!faster)
            {
                blocksRemaining++;
            }
            else
            {
                blocksRemaining = 0;
            }
        }

        if (blocksRemaining <= 0)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().LaadVolgendLevel();
        }
    }

    void Update()
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

        if (Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel("menu");
        }
    }
}
