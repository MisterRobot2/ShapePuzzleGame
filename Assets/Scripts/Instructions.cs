using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public GameObject instructionsUI;
    private bool instructionsOpen = false;

	// Use this for initialization
	void Start () {
        instructionsUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstructionsButton()
    {
        if (instructionsOpen == false)
        {
            instructionsUI.SetActive(true);
            instructionsOpen = true;
        }
        else if(instructionsOpen == true)
        {
            instructionsUI.SetActive(false);
            instructionsOpen = false;
        }
    }
}
