using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DubleClickClosePannelForButtions : MonoBehaviour
{
    [SerializeField]
    private GameObject Object;
    private bool isActive;
    
    public void ClosePannel()
    {
        if (Object.activeInHierarchy == true)
        {
           Object.gameObject.SetActive(false);
           isActive = false;
        }
        else
        {
            Object.gameObject.SetActive(true);
            isActive = true;
        }
    }
}
