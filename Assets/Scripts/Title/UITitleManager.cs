using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class UITitleManager : MonoBehaviour
{
    public void LoadGameScene()
    {      
        EditorSceneManager.LoadScene("Main");  
    }

    public void QuitGame()
    {     
       Application.Quit();
    }
}
