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
<<<<<<< HEAD
    public Slider speedSlider;
    public Toggle sound;
    private bool isAudioPaused = false;
=======
>>>>>>> ad705f06c6b951dfcd9294516a1260f863499a2f

    #region SpeedSlider
    public Slider speedSlider;
    #endregion
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

<<<<<<< HEAD
    public void ToggleSound()
    {
        if (sound)
        {
            AudioListener.pause = true;
        }
        else if(!sound)
        {
            AudioListener.pause = false;
        }
    }
=======
>>>>>>> ad705f06c6b951dfcd9294516a1260f863499a2f
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
