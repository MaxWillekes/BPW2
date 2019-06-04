using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string levelName;

    public void LaadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }

    public void LaadVolgendLevel(){
        SceneManager.LoadScene(levelName);
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