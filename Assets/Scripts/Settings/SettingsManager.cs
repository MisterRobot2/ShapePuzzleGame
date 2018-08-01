using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    #region FullScreen
    public Toggle windowMode;
    private bool isFullScreen;
    #endregion
    public Toggle sound;
    private int gameCounter = 0;
    public GameObject checkmark;

    #region SpeedSlider
    public Slider speedSlider;
    #endregion
    void Start ()
    {
        //  DontDestroyOnLoad(this.gameObject);
        FullscreenSetUp();
        speedSlider.minValue = 0;
        speedSlider.maxValue = 20;

        checkmark.SetActive(false);

        if (gameCounter == 0)
        {
            PlayerPrefs.SetInt("Is Audio Paused", 0);
            checkmark.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Is Audio Paused") == 0 && gameCounter > 1)
        {
            checkmark.SetActive(true);
        }

        gameCounter++;
    }

    void Update()
    {
        DataBase.speed = speedSlider.value;
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Is Audio Paused") == 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Is Audio Paused", 1);
        }
        else if(PlayerPrefs.GetInt("Is Audio Paused") == 1)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Is Audio Paused", 0);
        }
    }

    #region Fullscreen
    void FullscreenSetUp()
    {
        isFullScreen = Screen.fullScreen;
        windowMode.isOn = Screen.fullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void ToggleFullScreen()
    {
        if (Screen.fullScreen == true)
        {
            DataBase.isFullscreen = false;
            Screen.fullScreen = false;
            DataBase.isFullscreen = false;
            Debug.Log(DataBase.isFullscreen);
        }
        else if(Screen.fullScreen == false)
        {
            DataBase.isFullscreen = true;
            Screen.fullScreen = true;
            DataBase.isFullscreen = true;
            Debug.Log(DataBase.isFullscreen);
        }
    }
    #endregion
}
