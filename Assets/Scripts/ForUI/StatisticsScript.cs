using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour
{

    public GameObject statsUI;

    private void Awake()
    {
        statsUI.SetActive(true);
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetFloat("High Score")+"Ft";
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Placed Text").GetComponent<Text>().text = "Total Blocks Placed: " + PlayerPrefs.GetInt("Total Blocks Placed");
        GameObject.Find("Title UI").transform.Find("Stats Panel").transform.Find("Stats Text").transform.Find("Total Blocks Lost Text").GetComponent<Text>().text = "Total Blocks Lost: " + PlayerPrefs.GetInt("Total Blocks Lost");
        statsUI.SetActive(false);
    }

}
