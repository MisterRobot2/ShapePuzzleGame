using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   public void Pause()
    {
        if (DataBase.freezeGameSpeed == false)
        {
            Time.timeScale = 0;
        }
        
    }

   public void Continue()
    {
        if (DataBase.freezeGameSpeed == false)
        {
            Time.timeScale = 1;
        }
        
    }
}
