﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour
{

    public GameObject statsUI;

    private void Awake()
    {
        statsUI.SetActive(true);
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + CurrentData.gameData.highScore+"Ft";
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Placed Text").GetComponent<Text>().text = "Total Blocks Placed: " + CurrentData.gameData.totalBlocksPlaced;
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Lost Text").GetComponent<Text>().text = "Total Blocks Lost: " + CurrentData.gameData.totalBlocksLost;
        statsUI.SetActive(false);
    }

    public void ClearHighScore()
    {
        CurrentData.gameData.highScore = 0;
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + CurrentData.gameData.highScore + "Ft";
    }

    public void ClearTotalBlocksPlaced()
    {
        CurrentData.gameData.totalBlocksPlaced = 0;
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Placed Text").GetComponent<Text>().text = "Total Blocks Placed: " + CurrentData.gameData.totalBlocksPlaced;
    }

    public void ClearTotalBlocksLost()
    {
        CurrentData.gameData.totalBlocksLost = 0;
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Lost Text").GetComponent<Text>().text = "Total Blocks Lost: " + CurrentData.gameData.totalBlocksLost;
    }

    public void clearAllData()
    {
        SaveAndLoad.Delete();
    }

}
