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
        //gameOverUIPrefab.SetActive(true);
        Instantiate(gameOverUIPrefab);
        Time.timeScale = 0.3f;
    }
}
