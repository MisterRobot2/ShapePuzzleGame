using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   public void Pause()
    {
        if (GameData.freezeGameSpeed == false)
        {
            Time.timeScale = 0;
        }
        
    }

   public void Continue()
    {
        if (GameData.freezeGameSpeed == false)
        {
            Time.timeScale = 1;
        }
        
    }
}
