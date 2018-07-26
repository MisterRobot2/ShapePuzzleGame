using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    public GameObject PauseMenuUI;
    public GameObject OptionsUI;
    private bool isGamePaused = false;
    private AudioSource pauseMenuClick;

	void Start () {
        PauseMenuUI.SetActive(false);
        OptionsUI.SetActive(false);
        pauseMenuClick = PauseMenuUI.GetComponent<AudioSource>();
	}

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == false)
        {
            PauseMenuUI.SetActive(true);
            isGamePaused = true;
            Time.timeScale = 0.0f;
            pauseMenuClick.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused == true && !OptionsUI.activeSelf)
        {
            PauseMenuUI.SetActive(false);
            isGamePaused = false;
            Time.timeScale = 1.0f;
            pauseMenuClick.Play();
        }
    }

    public void ContinueButton()
    {
        PauseMenuUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1.0f;
        pauseMenuClick.Play();
    }

    public void OptionsButton()
    {
        OptionsUI.SetActive(true);
        pauseMenuClick.Play();
    }
}
