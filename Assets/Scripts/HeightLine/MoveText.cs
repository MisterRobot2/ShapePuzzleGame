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
        this.transform.position = parent.transform.position;
    }

    public void UpdateText(string newString)
    {
        if (revrseTextSide == false)
        {
           // this.transform.position = new Vector3(scailobjectScript.floatWidth, this.transform.position.y, this.transform.position.z);
            this.transform.position = new Vector3((newString.Length * .2f)*scailobjectScript.floatWidth + transform.parent.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        else if (revrseTextSide == false)
        {
           // this.transform.position = new Vector3(4.8f + (newString.Length * .2f) + transform.parent.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
