using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int indexOfSceneToLoad;
    public string nameOfSceneToLoad;

    public void LoadGameScene()
    {      
        SceneManager.LoadScene("Main");
        Time.timeScale = 1.0f;
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1.0f;
    }

    public void LoadSceneWithIndex()
    {
        SceneManager.LoadScene(indexOfSceneToLoad);
        Time.timeScale = 1.0f;
    }
    public void LoadSceneWithName()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {     
       Application.Quit();
    }
}
