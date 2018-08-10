using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderController : MonoBehaviour
{

    [SerializeField]
    private Slider Slider;
    [SerializeField]
    private Text Text;

    public void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        Text.text = (Mathf.Round(Slider.value * 100) / 100).ToString();
    }
}
