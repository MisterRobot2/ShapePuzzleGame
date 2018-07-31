﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{

    public static GameObject nextShape;
    #region GameVaribles

    public static int blocksPlacedInGame = 0;
    public static int totalScore = 0;

    public static bool isPlayerPlaying = false;
    public static int currentTeamNumber;

    public static float speed;

    public static Color32 team1Color;
    public static Color32 team2Color;

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
