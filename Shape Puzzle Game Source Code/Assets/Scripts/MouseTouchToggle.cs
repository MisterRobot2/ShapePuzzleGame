using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseTouchToggle : MonoBehaviour
{
    public Toggle MouseToggle;

    public void ToggleValue()
    {
        if (MouseToggle.isOn == true)
        {
            GameData.canMouseMoveBlock = true;
        }
        if (MouseToggle.isOn == false)
        {
            GameData.canMouseMoveBlock = false;
        }
    }
}
