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
        Time.timeScale = DataBase.gameSpeed;
        Debug.Log(DataBase.gameSpeed);
	}

    void FirstRun()
    {
        DataBase.freezeGameSpeed = false;
        DataBase.gameSpeed = 1f;
        Time.timeScale = 1f;
        iscalled = true;
    }

}
