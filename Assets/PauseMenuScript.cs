﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    public GameObject PauseMenuUI;
    private bool isGamePaused = false;

	void Start () {
        PauseMenuUI.SetActive(false);
	}

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == false)
        {
            PauseMenuUI.SetActive(true);
            isGamePaused = true;
            Time.timeScale = 0.0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == true)
        {
            PauseMenuUI.SetActive(false);
            isGamePaused = false;
            Time.timeScale = 1.0f;
        }
    }

    public void ContinueButton()
    {
        PauseMenuUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1.0f;
    }
}
