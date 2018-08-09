using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public int indexOfSceneToLoad;
    public string nameOfSceneToLoad;
    public GameMode selectGameMode;
    public void Start()
    {
        CurrentData.gameData.isFullscreen = Screen.fullScreen;
    }
    public void LoadGameScene()
    {
        SaveAndLoad.Load();
        Time.timeScale = 1.0f;
        GameData.team1coins = 0;
        GameData.team2coins = 0;
        GameData.team1Skips = 3;
        GameData.team2Skips = 3;
        SceneManager.LoadScene("Main");
    }

    public void LoadTitleScene()
    {
        
        if (GameData.isTutorial == true)
        {
            GameData.isTutorial = false;
        }

        Time.timeScale = 1.0f;
        GameData.team1coins = 0;
        GameData.team2coins = 0;

        if(SceneManager.GetActiveScene().name == "Store Scene"){
            SaveAndLoad.save();
        }

        SceneManager.LoadScene("Title");
        SaveAndLoad.Load();

        Debug.Log("scene"+ CurrentData.gameData.showHowTo);
    }

    public void LoadSceneWithIndex()
    {
        SaveAndLoad.Load();
        if(selectGameMode == GameMode.PassAndPlay)
        {
            GameData.namesExist = false;
        }
        if(CurrentData.gameData.showTipsEveryGame)
        {
            CurrentData.gameData.isFirstTime = true;
        } else{
            CurrentData.gameData.isFirstTime = false;
        }
        Time.timeScale = 1.0f;
        GameData.selectedMode = selectGameMode;
        SceneManager.LoadScene(indexOfSceneToLoad); 

        Debug.Log("before" + CurrentData.gameData.showHowTo);
    }
    public void LoadSceneWithName()
    {
        SaveAndLoad.Load();
        if (selectGameMode == GameMode.PassAndPlay)
        {
            GameData.namesExist = false;
        }
        if (CurrentData.gameData.showTipsEveryGame)
        {
            CurrentData.gameData.isFirstTime = true;
        } else{
            CurrentData.gameData.isFirstTime = false;
        }
        Time.timeScale = 1.0f;
        GameData.selectedMode = selectGameMode;
        SceneManager.LoadScene(nameOfSceneToLoad);
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
