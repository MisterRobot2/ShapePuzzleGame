using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGameSpeed : MonoBehaviour
{
	void Update ()
    {
        Time.timeScale = DataBase.gameSpeed;	
	}

    private void Start()
    {
        DataBase.freezeGameSpeed = false;
        Time.timeScale = 1;
        DataBase.gameSpeed = Time.timeScale;
    }
}
