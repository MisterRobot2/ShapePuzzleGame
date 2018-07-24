using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UITitleManager : MonoBehaviour
{
    public void LoadGameScene()
    {      
        SceneManager.LoadScene("Main");  
    }

    public void QuitGame()
    {     
       Application.Quit();
    }
}
