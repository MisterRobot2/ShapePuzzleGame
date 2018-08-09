using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public enum GameMode { SinglePlayer, PassAndPlay, Online };

[System.Serializable]
public static class CurrentData
{
    public static DataBase gameData = new DataBase();
}
[System.Serializable]
public static class SaveAndLoad
{
    static BinaryFormatter bf = new BinaryFormatter();
    

    public static void save()
    {   
        //create directory
        if(!Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
        FileStream file = File.Create(Application.dataPath + "/Saves/save.CloudBuster");
        bf.Serialize(file,CurrentData.gameData);
        file.Close();
    }

    public static void Load()
    {
        //check directory
        if(Directory.Exists(Application.dataPath + "/Saves"))
        {
            //check for file
            if(File.Exists(Application.dataPath + "/Saves/save.CloudBuster"))
            {
                FileStream file = File.Open(Application.dataPath + "/Saves/save.CloudBuster",FileMode.Open);
                CurrentData.gameData = (DataBase)bf.Deserialize(file);
                file.Close();
            }
        }else
        {
            Debug.LogWarning("CANT FIND FILE SAVING");
            //save();
        }
    }

    public static void Delete()
    {
        if (Directory.Exists(Application.dataPath + "/Saves"))
        {
            //check for file
            if (File.Exists(Application.dataPath + "/Saves/save.CloudBuster"))
            {
                Debug.Log("Deleted from " + Application.dataPath + "/Saves/save.CloudBuster");
                File.Delete(Application.dataPath + "/Saves/save.CloudBuster");
            }
        }
        CurrentData.gameData = new DataBase();
        save();
    }
}
// Does not get saved
public static class GameData
{
    public static int blocksPlacedInGame = 0;
    public static GameObject nextShape;
    public static GameMode selectedMode = GameMode.PassAndPlay;
    public static bool isPlayerPlaying = false;
    public static int currentTeamNumber;
    public static  float currentHeight;
    public static Color32 team1Color;
    public static Color32 team2Color;
    public static  int team1coins = 0;
    public static int team2coins = 0;
    public static int team1Skips = 3;
    public static int team2Skips = 3;
    public static float gameSpeed;
    public static float ScreenWidth;
    public static string team1Name;
    public static string team2Name;
    public static bool canSpawnShape = true;
    public static float oldSpeed;
    public static bool blockIsFalling = false;
    public static bool freezeGameSpeed = false;
    public static bool namesExist = false;
    public static bool isTutorial;
    public static bool firstDrop;
    public static bool firstGoalLine;
    public static bool firstSkip;
    public static bool firstCoin;
    public static bool firstSlowDown;
    public static bool isGameOver = false;
    public static bool canGameOver;
    public static bool canCollectCoin;
    public static bool canSkip;
    public static bool isMobile;
    public static bool canTouchMoveBlock = true;
}


[System.Serializable]
public class DataBase
{

    public float gameSpeed = 1f;
    public float blockSpeed = 6;

    public float highScore = 0;
    public float totalBlocksLost = 0;
    public float totalBlocksPlaced = 0;
    public int totalCoins = 0;

    //is Toggle on
    public bool iceBlockToggleIsOn = false;
    public bool phoneToggleIsOn = false;
    public bool waterGunToggleIsOn = false;
    public bool orbToggleIsOn = false;
    public bool tableToggleIsOn = false;
    public bool bookToggleIsOn = false;
    public bool bookShelfToggleIsOn = false;
    //purchesed
    public bool iceBlockBought = false;
    public bool phoneBought = false;
    public bool waterGunBought = false;
    public bool orbBought = false;
    public bool tableBought = false;
    public bool bookBought = false;
    public bool bookShelfBought = false;

    //tutorial + first time things
    public bool isFirstTime = true;
    public bool isFullscreen;
    public bool showTipsEveryGame = false;
    public float volume = 1;

}
