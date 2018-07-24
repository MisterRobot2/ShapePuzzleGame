using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject teamUIPrefab;
    private GameObject teamUIObject;
    private GameObject enterNamePannel;

    private Button submitButton;
    private GameObject team1Arrow;
    private GameObject team2Arrow;
    private Text team1NameText;
    private Text team2NameText;
    private Image team1Background;
    private Image team2Background;
    private Color team1Color;
    private Color team2Color;
    private Dropdown pickAColorDropdown;
    private string team1Name;
    private string team2Name;

	// Use this for initialization
	void Start ()
    {
        //Create TeamUI
        teamUIObject = Instantiate(teamUIPrefab);
        teamUIObject.transform.position = Vector3.zero;

        //Get Objects
        enterNamePannel = teamUIObject.transform.Find("Enter Name Pannel").gameObject;
        team1Arrow = teamUIObject.transform.Find("Team 1 Arrow").gameObject;
        team2Arrow = teamUIObject.transform.Find("Team 2 Arrow").gameObject;
        submitButton = enterNamePannel.transform.Find("Submit Buttion").gameObject.GetComponent<Button>();
        team1Background = teamUIObject.transform.Find("Team Names").Find("Team 1 Background").GetComponent<Image>();
        team2Background = teamUIObject.transform.Find("Team Names").Find("Team 2 Background").GetComponent<Image>(); ;
        team1NameText = team1Background.gameObject.transform.Find("Team 1 Name Text").GetComponent<Text>();
        team2NameText = team2Background.gameObject.transform.Find("Team 2 Name Text").GetComponent<Text>();
        pickAColorDropdown = enterNamePannel.transform.Find("Pick a Color Dropdown").gameObject.GetComponent<Dropdown>();

        //Setup Objects
        team1Arrow.SetActive(false);
        team2Arrow.SetActive(false);
        enterNamePannel.SetActive(false);
        submitButton.onClick.AddListener(delegate { submitNamePannel(); });

        //Start Game
        openNamePannel(1);
	}

    void openNamePannel(int teamNumber)
    {
        enterNamePannel.SetActive(true);
        if (teamNumber == 1)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Team 1";
            team1Arrow.SetActive(true);
            team2Arrow.SetActive(false);
        }
        else if(teamNumber == 2)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Team 2";
            team1Arrow.SetActive(false);
            team2Arrow.SetActive(true);
        }
    }

    public void submitNamePannel()
    {
        if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Team 1")
        {
            team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text = "";
            openNamePannel(2);
            changeTeamColor(1);
            pickAColorDropdown.value = 0;
        }
        else if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Team 2")
        {
            team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.SetActive(false);
            changeTeamColor(2);
        }
    }

    Color detectPlayerColorChoice()
    {
        switch (pickAColorDropdown.value)
        {
            case 0:
                return new Color(255, 255, 255, 255);

            case 1:
                return new Color(255, 0, 0, 255);

            case 2:
                return new Color(255, 102, 0, 255);
            case 3:
                return new Color(255, 204, 0, 255);

            case 4:
                return new Color(0, 0, 255, 255);

            case 5:
                return new Color(113, 55, 255, 255);

            case 6:
                return new Color(255, 0, 204, 255);

            case 7:
                return new Color(218, 218, 218, 255);

            case 8:
                return new Color(0, 0, 255, 255);
            default:
                return new Color(255, 0, 135, 255);
        }
    }

    void changeTeamColor(int teamNumber)
    {
        
        if(teamNumber == 1)
        {
            team1Color = detectPlayerColorChoice();
            team1NameText.text = team1Name;
            team1Background.color = team1Color;
            Debug.Log(team1Color);
        }else if (teamNumber == 2)
        {
            team2Color = detectPlayerColorChoice();
            team2NameText.text = team2Name;
            team2Background.color = team2Color;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
