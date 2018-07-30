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
    private GameObject team1Arrow;
    private GameObject team2Arrow;
    private GameObject spawner;
    private Button submitButton;
    private Text team1NameText;
    private Text team2NameText;
    private Text notificationPannelText;
    private Image team1Background;
    private Image team2Background;
    private Color team1Color;
    private Color team2Color;
    private Dropdown pickAColorDropdown;
    private string team1Name;
    private string team2Name;
    private int currentTeamNumber;
    private Animator teamUIAnimator;

	// Use this for initialization
	void Start ()
    {
        //Create UI Elements/Objects
        #region Create Objects
        //Create TeamUI
        teamUIObject = Instantiate(teamUIPrefab);
        teamUIObject.transform.position = Vector3.zero;
        #endregion

        //Get Objects
        #region get objects
        enterNamePannel = teamUIObject.transform.Find("Enter Name Pannel").gameObject;
        submitButton = enterNamePannel.transform.Find("Submit Buttion").gameObject.GetComponent<Button>();
        team1Background = teamUIObject.transform.Find("Team Names").Find("Team 1 Background").GetComponent<Image>();
        team2Background = teamUIObject.transform.Find("Team Names").Find("Team 2 Background").GetComponent<Image>(); ;
        team1NameText = team1Background.gameObject.transform.Find("Team 1 Name Text").GetComponent<Text>();
        team2NameText = team2Background.gameObject.transform.Find("Team 2 Name Text").GetComponent<Text>();
        team1Arrow = team1Background.transform.Find("Team 1 Arrow").gameObject;
        team2Arrow = team2Background.transform.Find("Team 2 Arrow").gameObject;
        pickAColorDropdown = enterNamePannel.transform.Find("Pick a Color Dropdown").gameObject.GetComponent<Dropdown>();
        teamUIAnimator = teamUIObject.GetComponent<Animator>();
        notificationPannelText = teamUIObject.transform.Find("NotificationPannel").transform.Find("Text").GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        #endregion

        //Setup Objects
        #region Setup Objects
        team1Arrow.SetActive(false);
        team2Arrow.SetActive(false);
        enterNamePannel.SetActive(false);
        submitButton.onClick.AddListener(delegate { submitNamePannel(); });
        DataBase.blocksPlacedInGame = 0;
        DataBase.isGameOver = true;
        #endregion

        //Start Game
        openNamePannel(1);
	}

    void openNamePannel(int teamNumber)
    {
        //if team 1
        enterNamePannel.SetActive(true);
        if (teamNumber == 1)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Player 1";
            team1Arrow.SetActive(true);
            team2Arrow.SetActive(false);
        }
        //if team 2
        else if(teamNumber == 2)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Player 2";
            team1Arrow.SetActive(false);
            team2Arrow.SetActive(true);
        }
    }

    public void submitNamePannel()
    {
        //Team 1
        if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Player 1")
        {
            team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text = "";
            openNamePannel(2);
            changeTeamColor(1);
            pickAColorDropdown.value = 0;
        }
        //Team 2
        else if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Player 2")
        {
            team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
            enterNamePannel.SetActive(false);
            changeTeamColor(2);
            DataBase.isGameOver = false;
            StartCoroutine(showNotificationPannel("Go first " + team1Name, 2));
            currentTeamNumber = 1;
            team1Arrow.SetActive(true);
            team2Arrow.SetActive(false);
            DataBase.isPlayerPlaying = true;
            GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
            spawner.GetComponent<shapeSpawner>().SpawnShape();

        }
    }

    IEnumerator showNotificationPannel(string whatToSay,int waitTime)
    {
        notificationPannelText.text = whatToSay;
        teamUIAnimator.SetBool("isNotificationPannelOpen", true);
        yield return new WaitForSeconds(waitTime);
        teamUIAnimator.SetBool("isNotificationPannelOpen", false);
    }

    void showNotificationPannel(string whatToSay,bool StayForever)
    {
        if(StayForever)
        {
            notificationPannelText.text = whatToSay;
            teamUIAnimator.SetBool("isNotificationPannelOpen", true);
        }else
        {
            teamUIAnimator.SetBool("isNotificationPannelOpen", false);
        }
    }

    void Turns()
    {
        if(currentTeamNumber == 1)
        {
            currentTeamNumber = 2;
            team2Arrow.SetActive(true);
            team1Arrow.SetActive(false);
            StartCoroutine(showNotificationPannel("Your Turn, " + team2Name+"!", 2));
        }else if (currentTeamNumber == 2)
        {
            currentTeamNumber = 1;
            team1Arrow.SetActive(true);
            team2Arrow.SetActive(false);
            StartCoroutine(showNotificationPannel("Your Turn, "+team1Name+"!", 2));
        }
        DataBase.currentTeamNumber = currentTeamNumber;
        DataBase.isPlayerPlaying = true;
        spawner.GetComponent<shapeSpawner>().SpawnShape();
    }

    //Returns color that player picked
    Color32 detectPlayerColorChoice()
    {
        #region colors
        switch (pickAColorDropdown.value)
        {
            //red
            case 0:
                return new Color32(255, 0, 0, 255);
            //orange
            case 1:
                return new Color32(255, 102, 0, 255);
            //yellow
            case 2:
                return new Color32(255, 204, 0, 255);
            //Green
            case 3:
                return new Color32(40, 120, 40, 255);
            //Blue
            case 4:
                return new Color32(0, 0, 255, 255);
            //Purple
            case 5:
                return new Color32(113, 55, 255, 255);
            //Pink
            case 6:
                return new Color32(255, 0, 204, 255);
            //Grey
            case 7:
                return new Color32(218, 218, 218, 255);
            default:
                return new Color32(255, 0, 135, 255);
        }
        #endregion
    }

    void changeTeamColor(int teamNumber)
    {
        //for team 1
        if(teamNumber == 1)
        {
            team1Color = detectPlayerColorChoice();
            team1NameText.text = team1Name;
            team1Background.color = team1Color;
            DataBase.team1Color = team1Color;

            //Debug.Log(team1Color);

        //for team 2

        }else if (teamNumber == 2)
        {
            team2Color = detectPlayerColorChoice();
            team2NameText.text = team2Name;
            team2Background.color = team2Color;
            DataBase.team2Color = team2Color;
        }
    }
	
    IEnumerator placeBlockCountDown(int time)
    {
        DataBase.isPlayerPlaying = false;
        #region countdown
        for (int i = time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            //if there is a game over
            if(DataBase.isGameOver)
            {
                if(currentTeamNumber == 1)
                {
                    showNotificationPannel("" + team2Name + " WINS!",true);
                }
                else if (currentTeamNumber == 2)
                {
                    showNotificationPannel("" + team1Name + " WINS!", true);
                }
                break;
            }           
        }
        #endregion
        #region end of turn
        if (currentTeamNumber == 1 && !DataBase.isGameOver)
        {
            StartCoroutine(showNotificationPannel("Good Job " + team1Name, 2));
            yield return new WaitForSeconds(2);
            StartCoroutine(showNotificationPannel("Now go " + team2Name + "!", 2));
            Turns();
        }
        else if (currentTeamNumber == 2 && !DataBase.isGameOver)
        {
            StartCoroutine(showNotificationPannel("Good Job " + team2Name, 2));
            yield return new WaitForSeconds(2);
            StartCoroutine(showNotificationPannel("Now go " + team1Name + "!", 2));
            Turns();
            
        }
        #endregion
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Space) && DataBase.isPlayerPlaying)
        {
            StartCoroutine(placeBlockCountDown(0));
        }
	}
}
