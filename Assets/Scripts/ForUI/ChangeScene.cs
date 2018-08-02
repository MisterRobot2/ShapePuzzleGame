using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int indexOfSceneToLoad;
    public string nameOfSceneToLoad;
    public GameMode selectGameMode;

    public void LoadGameScene()
    {
        Time.timeScale = 1.0f;
        DataBase.team1coins = 0;
        DataBase.team2coins = 0;
        DataBase.team1Skips = 3;
        DataBase.team2Skips = 3;
        SceneManager.LoadScene("Main");
    }

    public void LoadTitleScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title"); 
    }

    public void LoadSceneWithIndex()
    {
        Time.timeScale = 1.0f;
        DataBase.selectedMode = selectGameMode;
        SceneManager.LoadScene(indexOfSceneToLoad); 
    }
    public void LoadSceneWithName()
    {
        Time.timeScale = 1.0f;
        DataBase.selectedMode = selectGameMode;
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

    public void QuitGame()
    {     
       Application.Quit();
    }
}
