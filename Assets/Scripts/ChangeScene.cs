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
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadSceneWithIndex()
    {
        SceneManager.LoadScene(indexOfSceneToLoad);
    }
    public void LoadSceneWithName()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

    public void QuitGame()
    {     
       Application.Quit();
    }
}
