using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    [SerializeField]
    private bool revrseTextSide;
    [SerializeField]
    private GameObject parent;


    public void UpdateText(string newString)
    {
        if (revrseTextSide == false)
        {
                                                                          //V Change this number for tweek
            this.transform.position = new Vector3(GameData.ScreenWidth*.34f + (newString.Length * (GameData.ScreenWidth * .011f)), parent.transform.position.y, this.transform.position.z);
        }
        else if (revrseTextSide == true)
        {
            this.transform.position = new Vector3((GameData.ScreenWidth * .34f + (newString.Length * (GameData.ScreenWidth * .011f)))*-1, parent.transform.position.y, this.transform.position.z);
        }
    }
}
