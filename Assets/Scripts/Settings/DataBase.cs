using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { SinglePlayer, PassAndPlay, Online };

public static class DataBase
{

    public static GameObject nextShape;
    public static GameMode selectedMode = GameMode.SinglePlayer;

    #region GameVaribles

    public static int blocksPlacedInGame = 0;

    public static bool isPlayerPlaying = false;
    public static int currentTeamNumber;

    public static float speed;

    public static Color32 team1Color;
    public static Color32 team2Color;

    public static int team1coins;
    public static int team2coins;

    public static int totalCoins = 33;

    public static int team1Skips = 3;
    public static int team2Skips = 3;

    public static bool canSpawnShape = true;


    //Game Speed
    public static float gameSpeed = 1f;
    public static bool freezeGameSpeed = false;


    #endregion

    #region PlayerStats
    public static int totalBlocksPlaced;
    public static int totalBlocksLost;
    public static float highScore;
    
    public static bool isGameOver = true;
    
    #endregion

    #region Settings
    static public bool isFullscreen;

    #endregion



}
