using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    [SerializeField]
    private bool revrseTextSide;
    private ScailOBject scailobjectScript;
    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        scailobjectScript = gameObject.GetComponent<ScailOBject>();
    }

    private void Update()
    {

    }

    public void UpdateText(string newString)
    {
        scailobjectScript = gameObject.GetComponent<ScailOBject>();
        if (revrseTextSide == false)
        {
                                                                          //V Change this number for tweek
            this.transform.position = new Vector3(scailobjectScript.width*.34f + (newString.Length * (scailobjectScript.width*.011f)), parent.transform.position.y, this.transform.position.z);
        }
        else if (revrseTextSide == true)
        {
            this.transform.position = new Vector3((scailobjectScript.width * .34f + (newString.Length * (scailobjectScript.width * .011f)))*-1, parent.transform.position.y, this.transform.position.z);
        }
    }
}
