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
        DataBase.gameSpeed = speedSlider.value;
        speedText.text = (Mathf.Round(Time.timeScale * 100)/100).ToString();
    }
}
