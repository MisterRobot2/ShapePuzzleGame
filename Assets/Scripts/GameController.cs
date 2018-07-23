using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject teamUI;
    private GameObject enterNamePannel;

    private string team1Name;
    private string team2Name;

	// Use this for initialization
	void Start ()
    {
        //Get Objects
        enterNamePannel = teamUI.transform.Find("Enter Name Pannel").gameObject;

        enterNamePannel.SetActive(false);
        openNamePannel(1);
	}

    void openNamePannel(int teamNumber)
    {
        enterNamePannel.SetActive(true);
        if (teamNumber == 1)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Team 1";
        }else if(teamNumber == 2)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Team 2";
        }
    }

    public void submitNamePannel(int teamNumber)
    {
        if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Team 1")
        {
            team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text = "";
            openNamePannel(2);
        }
        else if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Team 2")
        {
            team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
