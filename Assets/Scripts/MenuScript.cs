using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel1()
    {
        Destroy(GameObject.FindGameObjectWithTag("MenuAudioGameObject"));
        SceneManager.LoadScene("lvl1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void LoadIntermission1()
    {
        SceneManager.LoadScene("Intermission1");
    }

    public void LoadIntermission2()
    {
        SceneManager.LoadScene("Intermission2");
        LevelManager.instance.levelNumber = 3;
    }

    public void LoadIntermission3()
    {
        SceneManager.LoadScene("Intermission3");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void BackToMenu()
    {
        if (GameObject.FindGameObjectWithTag("MenuAudioGameObject"))
        {
            Destroy(GameObject.FindGameObjectWithTag("MenuAudioGameObject"));
        }

        SceneManager.LoadScene("Menu");
    }

    public void ToCredits()
    {
        LevelManager.instance.levelNumber = 1;
        LevelManager.instance.lives = 3;
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
