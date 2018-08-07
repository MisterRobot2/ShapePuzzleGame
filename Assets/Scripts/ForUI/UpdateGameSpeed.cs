using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGameSpeed : MonoBehaviour
{
    private bool iscalled;
	void Update ()
    {
        if (iscalled == false)
        {
            FirstRun();
        }
        Time.timeScale = CurrentData.gameData.gameSpeed;
	}

    void FirstRun()
    {
        GameData.freezeGameSpeed = false;
        CurrentData.gameData.gameSpeed = 1f;
        Time.timeScale = 1f;
        iscalled = true;
    }

}
