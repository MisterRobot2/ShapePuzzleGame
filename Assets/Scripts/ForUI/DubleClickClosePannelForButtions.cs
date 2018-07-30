using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubleClickClosePannelForButtions : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the object the toggle will effect on")]
    private GameObject[] ToggleObject = new GameObject[0];
    [SerializeField]
    [Tooltip("when the toggle is true it will pause the game when the pannel is active")]
    private bool pauseWhenActive;
    
    [SerializeField]
    [Tooltip("if true the toggle will work by keypress")]
    private bool activeByKey;
    [SerializeField]
    [Tooltip("If the active by key is true the toggle is work with selected key")]
    private KeyCode keyToTrigger;
    
    [SerializeField]
    [Tooltip("Force closes all pannels when main pannel is not active")]
    private bool forceClose;
    [SerializeField]
    [Tooltip("Objects to force close")]
    private GameObject[] objectsToForceClose = new GameObject[0];



    private bool isActive;

    private void Update()
    {
        if (activeByKey == true)
        {
            if (Input.GetKeyDown(keyToTrigger))
            {
                ClosePannel();
            }
        }
    }


    public void ClosePannel()
    {
        foreach (var Object in ToggleObject)
        {
            if (Object.activeInHierarchy == true)
            {
                foreach (var forceCloseObjects in objectsToForceClose)
                {
                    forceCloseObjects.SetActive(false);
                }
                Object.gameObject.SetActive(false);
                isActive = false;

                if (pauseWhenActive == true)
                {
                    Time.timeScale = 1;
                }
            }
            else
            {
                Object.gameObject.SetActive(true);
                isActive = true;

                if (pauseWhenActive == true)
                {
                    Time.timeScale = 0;
                }
            }
        }  
        
    }
}
