using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataBase
{

    public static GameObject nextShape;
    #region PlayerStats

    public static int score = 0;
    public static int highScore = 0;
    public static int totalScore = 0;
    public static bool isGameOver = true;
    public static bool isPlayerPlaying = false;
    public static int currentTeamNumber;
    public static Color32 team1Color;
    public static Color32 team2Color;
    #endregion

    #region Settings
    static public bool isFullscreen;

    #endregion



}
