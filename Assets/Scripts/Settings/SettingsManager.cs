﻿using System.Collections;
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
<<<<<<< HEAD
=======
    private bool isAudioPaused = false;

>>>>>>> e2b6feac06400dbcb7ea7d656fe3ff43dd2d72e8

    #region SpeedSlider
    public Slider speedSlider;
    #endregion
    void Start ()
    {
        //DontDestroyOnLoad(this.gameObject);
        FullscreenSetUp();
        speedSlider.minValue = 0;
        speedSlider.maxValue = 20;
       
    }

    void Update()
    {
        DataBase.speed = speedSlider.value;
    }

<<<<<<< HEAD
    public void SoundToggle()
=======
    public void ToggleSound()
>>>>>>> e2b6feac06400dbcb7ea7d656fe3ff43dd2d72e8
    {
        if (DataBase.isSoundPaused == false)
        {
            AudioListener.volume = 0f;
            DataBase.isSoundPaused = true;
        }
        else if (DataBase.isSoundPaused == true)
        {
            AudioListener.volume = 1f;
            DataBase.isSoundPaused = false;
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
