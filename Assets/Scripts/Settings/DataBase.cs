﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode { SinglePlayer, PassAndPlay, Online };

public static class DataBase
{

    public static GameObject nextShape;
    public static GameMode selectedMode = GameMode.PassAndPlay;

    #region GameVaribles

    public static int blocksPlacedInGame = 0;

    public static bool isPlayerPlaying = false;
    public static int currentTeamNumber;

    public static float speed;
    public static float currentHeight;

    public static Color32 team1Color;
    public static Color32 team2Color;

    public static int team1coins;
    public static int team2coins;

    public static int totalCoins = 9999999;

    public static int team1Skips = 3;
    public static int team2Skips = 3;

    public static string team1Name;
    public  static string team2Name;


    public static bool canSpawnShape = true;
    //is Toggle on
    public static bool iceBlockToggleIsOn = false;
    public static bool phoneToggleIsOn = false;
    public static bool waterGunToggleIsOn = false;
    public static bool orbToggleIsOn = false;
    public static bool tableToggleIsOn = false;
    public static bool bookToggleIsOn = false;
    public static bool bookShelfToggleIsOn = false;
    //purchesed
    public static bool iceBlockBought = false;
    public static bool phoneBought = false;
    public static bool waterGunBought = false;
    public static bool orbBought = false;
    public static bool tableBought = false;
    public static bool bookBought = false;
    public static bool bookShelfBought = false;

    //Game Speed
    public static float gameSpeed = 1f;
    public static float oldSpeed;
    public static bool freezeGameSpeed = false;


    //tutorial
    public static bool isFirstTime = true;

    #endregion

    #region PlayerStats
    public static int totalBlocksPlaced;
    public static int totalBlocksLost;
    public static float highScore;
    
    public static bool isGameOver = true;
    
    #endregion

    #region Settings
    static public bool isFullscreen;
    static public bool isAudioOn = true;

    #endregion

    #region TutorialVariables

    public static bool firstDrop = false;
    public static bool firstGoalLine = false;
    public static bool firstSkip = false;
    public static bool firstSlowDown = false;

    #endregion




}
