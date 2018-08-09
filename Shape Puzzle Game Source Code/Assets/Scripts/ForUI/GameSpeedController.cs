using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private Text speedText;

    public void UpdateGameSpeed()
    {
        CurrentData.gameData.gameSpeed = speedSlider.value;
        speedText.text = (Mathf.Round(Time.timeScale * 100)/100).ToString();
    }

    private void Start()
    {
        GameData.freezeGameSpeed = false;
        Time.timeScale = 1;
        //CurrentData.gameData.gameSpeed = Time.time;
    }
}
