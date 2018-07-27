using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {


    public GameObject gameOverUIPrefab;
    private AudioSource gameOverSound;

    void Start ()
    {
        gameOverUIPrefab.SetActive(false);
        gameOverSound = gameOverUIPrefab.GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DataBase.score--;
        //Create Game Over If 
        if(!DataBase.isGameOver)
        {
            DataBase.isGameOver = true;
            GameObject gameOverObject = Instantiate(gameOverUIPrefab);
            gameOverObject.name = "Game Over";
            //blocks placed text 
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: " + DataBase.score;
        }
        if(DataBase.isGameOver == true)
        {
            gameOverUIPrefab.SetActive(true);
            gameOverSound.Play();
            Time.timeScale = 0.3f;
        }
    }
}
