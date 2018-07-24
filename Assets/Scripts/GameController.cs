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
            team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text = "";
            openNamePannel(2);
            changeTeamColor(1);
        }
        else if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Team 2")
        {
            team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.SetActive(false);
            changeTeamColor(2);
        }
    }

    void changeTeamColor(int teamNumber)
    {
        Color newColor;
        switch (pickAColorDropdown.value)
        {
            case 0:
                newColor = new Color(255, 255, 255);
                break;
            case 1:
                newColor = new Color(255, 0, 0);
                break;
            case 2:
                newColor = new Color(255, 102, 0);
                break;
            case 3:
                newColor = new Color(255, 204, 0);
                break;
            case 4:
                newColor = new Color(0, 0, 255);
                break;
            case 5:
                newColor = new Color(113, 55, 255);
                break;
            case 6:
                newColor = new Color(255, 0, 204);
                break;
            case 7:
                newColor = new Color(218, 218, 218);
                break;
            case 8:
                newColor = new Color(0, 0, 255);
                break;
            default:
                break;
        }
        Debug.Log("SSS");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
