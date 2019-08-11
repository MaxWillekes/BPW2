using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int levelNumber = 1;

    public int score;
    public int lives;

    public Text scoreText;
    public Text livesText;

    public bool InfiniLives;

    public static LevelManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
            livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>();

            DontDestroyOnLoad(gameObject);

            lives = 3;
            score = 0;
        }
        else
        {
            Destroy(gameObject);
        }

        if(InfiniLives == true)
        {
            lives = 999999999;
        }
    }

    public void Update()
    {
        if (InfiniLives == true && GameObject.FindGameObjectWithTag("EnergyBar"))
        {
            GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<Image>().fillAmount = 100;
        }
    }

    public void LaadVolgendLevel() {
        if(levelNumber >= 4)
        {
            levelNumber = 0;
        }
        levelNumber++;
        SceneManager.LoadScene("lvl" + levelNumber);
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>();
    }

    public void back()
    {
        levelNumber = 1;
        lives = 3;
        SceneManager.LoadScene("menu");
    }

    public void StopSpel()
    {
        Application.Quit();
    }

    public void ScoreUp(int Type)
    {
        switch (Type)
        {
            case 0:
                score += Random.Range(1, 5);
                break;
            case 1:
                score += Random.Range(6, 10);
                break;
            case 2:
                score += Random.Range(11, 15);
                break;
        }

        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Score : " + score;
    }

    public void LivesDown()
    {
        lives--;
        GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>().text = "Hull integrity : " + lives;
    }

    public void LivesUp()
    {
        lives++;
        GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>().text = "Hull integrity : " + lives;
    }
}