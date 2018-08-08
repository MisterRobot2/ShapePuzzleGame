using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPannel;
    [SerializeField]
    private Toggle windowModeToggle;
    public Slider volumeSlider;
    public Slider speedSlider;
    public Toggle ShowTipsEveryGame;

    void OnEnable()
    {
        SaveAndLoad.Load();
        speedSlider.value = CurrentData.gameData.blockSpeed;
        windowModeToggle.isOn = CurrentData.gameData.isFullscreen;
        ShowTipsEveryGame.isOn = CurrentData.gameData.showTipsEveryGame;
        volumeSlider.value = CurrentData.gameData.volume;
    }
    void OnDisable()
    {
        UpdateData();
        SaveAndLoad.save();
    }

    public void UpdateData()
    {
        CurrentData.gameData.blockSpeed = speedSlider.value;
        CurrentData.gameData.isFullscreen = windowModeToggle.isOn;
        Screen.fullScreen = CurrentData.gameData.isFullscreen;
        CurrentData.gameData.showTipsEveryGame = ShowTipsEveryGame.isOn;
        CurrentData.gameData.volume = volumeSlider.value;
    }
}
