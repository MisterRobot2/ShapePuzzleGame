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
        GameData.team1coins = 0;
        GameData.team2coins = 0;
        GameData.team1Skips = 3;
        GameData.team2Skips = 3;
        SceneManager.LoadScene("Main");
        SaveAndLoad.save();
    }

    public void LoadTitleScene()
    {
        SaveAndLoad.save();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
        GameData.team1coins = 0;
        GameData.team2coins = 0;
    }

    public void LoadSceneWithIndex()
    {
        SaveAndLoad.Load();
        if(selectGameMode == GameMode.PassAndPlay)
        {
            GameData.namesExist = false;
        }
        CurrentData.gameData.isFirstTime = true;
        Time.timeScale = 1.0f;
        GameData.selectedMode = selectGameMode;
        SceneManager.LoadScene(indexOfSceneToLoad); 
    }
    public void LoadSceneWithName()
    {
        SaveAndLoad.Load();
        if (selectGameMode == GameMode.PassAndPlay)
        {
            GameData.namesExist = false;
        }

        CurrentData.gameData.isFirstTime = true;
        Time.timeScale = 1.0f;
        GameData.selectedMode = selectGameMode;
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

    public void QuitGame()
    {
       SaveAndLoad.save();
       Application.Quit();
    }
}
