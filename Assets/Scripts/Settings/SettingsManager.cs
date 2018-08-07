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
    private Toggle windowModeToggle;
    #endregion

    #region soundVaribles
    [SerializeField]
    private Toggle soundToggle;
    private int gameCounter = 0;
    
    #endregion

    public Slider speedSlider;
    public Toggle showControlsEveryGameToggle;

    void Start()
    {
        SaveAndLoad.Load();
        speedSlider.value = CurrentData.gameData.gameSpeed;
        Screen.fullScreen = CurrentData.gameData.isFullscreen;
        windowModeToggle.isOn = CurrentData.gameData.isFullscreen;
        soundToggle.isOn = CurrentData.gameData.isAudioOn;
    }

    void OnEnable()
    {
        SaveAndLoad.Load();
        speedSlider.value = CurrentData.gameData.gameSpeed;
        Screen.fullScreen = CurrentData.gameData.isFullscreen;
        windowModeToggle.isOn = CurrentData.gameData.isFullscreen;
        soundToggle.isOn = CurrentData.gameData.isAudioOn;
    }

    public void UpdateData()
    {
        CurrentData.gameData.gameSpeed = speedSlider.value;
        CurrentData.gameData.isFullscreen = Screen.fullScreen;
        CurrentData.gameData.isFullscreen = Screen.fullScreen;
        CurrentData.gameData.isFullscreen = windowModeToggle.isOn;
        CurrentData.gameData.isAudioOn = soundToggle.isOn;

        SaveAndLoad.save();
    }

    private void OnApplicationQuit()
    {
        SaveAndLoad.save();
    }
}
