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
    public Slider speedSlider;

    void Start ()
    {
      //  DontDestroyOnLoad(this.gameObject);
        FullscreenSetUp();
        speedSlider.minValue = 0;
        speedSlider.maxValue = 20;
	}

    void Update()
    {
        DataBase.speed = speedSlider.value;
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
