using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    [SerializeField]
    private bool revrseTextSide;

   public void UpdateText(string newString)
    {
        if (revrseTextSide == true)
        {
            this.transform.position = new Vector3(((4.8f + newString.Length * .2f) * -1) + transform.parent.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        else if (revrseTextSide == false)
        {
            this.transform.position = new Vector3(4.8f + (newString.Length * .2f) + transform.parent.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
