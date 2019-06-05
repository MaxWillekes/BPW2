using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int levelNumber = 1;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void LaadLevel(string levelName){
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void LaadVolgendLevel(){
        levelNumber++;
        SceneManager.LoadScene("lvl" + levelNumber);
    }

    public void back()
    {
        Application.LoadLevel("menu");
    }

    public void StopSpel()
    {
        Application.Quit();
    }
}