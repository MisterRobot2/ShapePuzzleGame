using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour {

    public GameObject statsUI;

	// Use this for initialization
	void Start () {
        GameObject.Find("UICanvas").transform.Find("Stats Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score");
        GameObject.Find("UICanvas").transform.Find("Stats Panel").transform.Find("Total Blocks Placed Text").GetComponent<Text>().text = "Total Blocks Placed: " + PlayerPrefs.GetInt("Total Blocks Placed");
        GameObject.Find("UICanvas").transform.Find("Stats Panel").transform.Find("Total Blocks Lost Text").GetComponent<Text>().text = "Total Blocks Lost: " + PlayerPrefs.GetInt("Total Blocks Lost");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
