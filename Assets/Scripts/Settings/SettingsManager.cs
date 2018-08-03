using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPannel;
    #region FullScreen varibles
    [SerializeField]
    private Toggle windowMode;
    private bool isFullScreen;
    #endregion

    #region soundVaribles
    [SerializeField]
    private Toggle sound;
    private int gameCounter = 0;
    
    #endregion

    #region SpeedSlider varibles
    public Slider speedSlider;
    #endregion

    void Start ()
    {
        optionsPannel.SetActive(true);
        FullscreenSetUp();
        UpdateSpeedSlider();
        setSoundToggle();
        optionsPannel.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        #region save Audio Settings
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Is Audio Paused", 0);
        }
        else if (AudioListener.volume == 1)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Is Audio Paused", 0);
        }
        #endregion

        #region save Slider value
        DataBase.speed = PlayerPrefs.GetFloat("GameSpeed", DataBase.speed);
        #endregion
    }

    #region SpeedSlider

    void UpdateSpeedSlider()
    {
        if (PlayerPrefs.GetFloat("GameSpeed") != 0)
        {
            DataBase.speed = PlayerPrefs.GetFloat("GameSpeed", DataBase.speed);
        }
        else
        {
            speedSlider.value = 20;
        }
        speedSlider.value = DataBase.speed;
        speedSlider.minValue = 0;
        speedSlider.maxValue = 20;
        PlayerPrefs.SetFloat("GameSpeed", DataBase.speed);

    }

    public void ChangeGameSpeed()
    {
        DataBase.speed = speedSlider.value;
        PlayerPrefs.SetFloat("GameSpeed", DataBase.speed);
    }

    #endregion

    #region Sound
    
    void setSoundToggle()
    {
        if (PlayerPrefs.GetInt("Is Audio Paused") == 1)
        {
            sound.isOn = false;
;           DataBase.isAudioOn = false;
        }
        else if (PlayerPrefs.GetInt("Is Audio Paused") == 0)
        {
            sound.isOn = true;
            DataBase.isAudioOn = true;
        }
    }
    public void ToggleSound()
    {

        if (PlayerPrefs.GetInt("Is Audio Paused") == 0)
        {

            AudioListener.volume = 0;
            sound.isOn = false;
            PlayerPrefs.SetInt("Is Audio Paused", 1);
        }
        else if (PlayerPrefs.GetInt("Is Audio Paused") == 1)
        {
            AudioListener.volume = 1;
            DataBase.isAudioOn = true;
            PlayerPrefs.SetInt("Is Audio Paused", 0);
            sound.isOn = true;
        }

    }

    #endregion

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
        }
        else if(Screen.fullScreen == false)
        {
            DataBase.isFullscreen = true;
            Screen.fullScreen = true;
            DataBase.isFullscreen = true;
        }
    }
    #endregion
}
