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
            Time.timeScale = 0;
        }
        else if(instructionsOpen == true)
        {
            instructionsUI.SetActive(false);
            instructionsOpen = false;
            Time.timeScale = 1;
        }
    }
}
