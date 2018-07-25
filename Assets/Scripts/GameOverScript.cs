using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public GameObject gameOverUI;

	void Start () {
        gameOverUI.SetActive(false);
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0.3f;
    }
}
