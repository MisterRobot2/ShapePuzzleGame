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


    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        FullscreenSetUp();
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
            Info.isFullscreen = false;
            Screen.fullScreen = false;
            Info.isFullscreen = false;
            Debug.Log(Info.isFullscreen);
        }
        else if(Screen.fullScreen == false)
        {
            Info.isFullscreen = true;
            Screen.fullScreen = true;
            Info.isFullscreen = true;
            Debug.Log(Info.isFullscreen);
        }
    }
    #endregion
}
