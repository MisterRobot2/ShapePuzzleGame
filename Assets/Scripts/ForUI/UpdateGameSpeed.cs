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
        Time.timeScale = GameData.gameSpeed;
	}

    void FirstRun()
    {
        GameData.freezeGameSpeed = false;
        GameData.gameSpeed = 1f;
        Time.timeScale = 1f;
        iscalled = true;
    }

}
