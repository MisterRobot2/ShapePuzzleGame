using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {


    public GameObject gameOverUIPrefab;

	void Start ()
    {
        //gameOverUIPrefab.SetActive(false);
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DataBase.score--;
        //Create Game Over If 
        if(!GameObject.Find("Game Over") && !DataBase.isGameOver)
        {
            DataBase.isGameOver = true;
            GameObject gameOverObject = Instantiate(gameOverUIPrefab);
            gameOverObject.name = "Game Over";
            //blocks placed text 
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: " + DataBase.score;
        }
        Time.timeScale = 0.3f;
    }
}
