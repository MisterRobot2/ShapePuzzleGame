using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject teamUIPrefab;
    [SerializeField]
    private GameObject singlePlayerPrefab;
    [SerializeField]
    private InputField debugFeild;

    private GameObject singlePlayerObject;
    private GameObject teamUIObject;
    private GameObject enterNamePannel;
    private GameObject team1Arrow;
    private GameObject team2Arrow;
    private GameObject spawner;
    private Button submitButton;
    private Button skipButton;
    private Button buySkipButton;
    private Text team1NameText;
    private Text team2NameText;
    private Text notificationPannelText;
    private Text team1CoinText;
    private Text team2CoinText;
    private Text singlePlayerCoinText;
    private Text skipButtonText;
    private Image team1Background;
    private Image team2Background;
    private Color team1Color;
    private Color team2Color;
    private Dropdown pickAColorDropdown;
    //private string team1Name;
    //private string team2Name;
    private int currentTeamNumber;
    private Animator teamUIAnimator;
    private int team1ColorValue;
    private bool isDueForBlock = false;
    private float waitTime;


	// Use this for initialization
	void Start ()
    {
        #region Create Objects
        //Pass and Play
        if(GameData.selectedMode == GameMode.PassAndPlay)
        {
            teamUIObject = Instantiate(teamUIPrefab);
            teamUIObject.transform.position = Vector3.zero;
        }
        //Singleplayer
        if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerObject = Instantiate(singlePlayerPrefab);
            singlePlayerObject.transform.position = Vector3.zero;
        }
        #endregion

        #region Get Objects
        //Pass and Play
        if(GameData.selectedMode == GameMode.PassAndPlay)
        {
            enterNamePannel = teamUIObject.transform.Find("Enter Name Pannel").gameObject;
            submitButton = enterNamePannel.transform.Find("Submit Buttion").gameObject.GetComponent<Button>();
            team1Background = teamUIObject.transform.Find("Team Names").Find("Team 1 Background").GetComponent<Image>();
            team2Background = teamUIObject.transform.Find("Team Names").Find("Team 2 Background").GetComponent<Image>();
            team1NameText = team1Background.gameObject.transform.Find("Team 1 Name Text").GetComponent<Text>();
            team2NameText = team2Background.gameObject.transform.Find("Team 2 Name Text").GetComponent<Text>();
            team1CoinText = team1Background.transform.Find("team1CoinText").GetComponent<Text>();
            team2CoinText = team2Background.transform.Find("team2CoinText").GetComponent<Text>();
            team1Arrow = team1Background.transform.Find("Team 1 Arrow").gameObject;
            team2Arrow = team2Background.transform.Find("Team 2 Arrow").gameObject;
            pickAColorDropdown = enterNamePannel.transform.Find("Pick a Color Dropdown").gameObject.GetComponent<Dropdown>();
            teamUIAnimator = teamUIObject.GetComponent<Animator>();
            notificationPannelText = teamUIObject.transform.Find("NotificationPannel").transform.Find("Text").GetComponent<Text>();
        }
        
        //SinglePlayer
        if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerCoinText = GameObject.Find("Coin Text").GetComponent<Text>();
        }

        //Game Objects
        skipButton = GameObject.Find("Shape Skip Button").GetComponent<Button>();
        buySkipButton = GameObject.Find("Buy Skip Button").GetComponent<Button>();
        skipButtonText = GameObject.Find("skipCounter").GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        #endregion

        #region Setup Objects
        //pass and play
        if(GameData.selectedMode == GameMode.PassAndPlay)
        {
            team1Arrow.SetActive(false);
            team2Arrow.SetActive(false);
            enterNamePannel.SetActive(false);
            submitButton.onClick.AddListener(delegate { submitNamePannel(); });
        }

        //Game Setup
        buySkipButton.gameObject.SetActive(false);
        GameData.blocksPlacedInGame = 0;
        GameData.isGameOver = true;
        GameData.team1Skips = 3;
        GameData.team2Skips = 3;
        #endregion

        #region Start Game
        //Pass and Play
        //WORKING HERE
        if (GameData.selectedMode == GameMode.PassAndPlay)
        {
            if(GameData.namesExist){
                currentTeamNumber = 1;
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                team1NameText.text = GameData.team1Name;
                team1Background.color = GameData.team1Color;
                team2NameText.text = GameData.team2Name;
                team2Background.color = GameData.team2Color;
                GameData.isPlayerPlaying = true;
                GameData.isGameOver = false;
                GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
                spawner.GetComponent<shapeSpawner>().SpawnShape();
            } else{
                openNamePannel(1);
            }

        }
        //SinglePlayer
        if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerObject.SetActive(true);
            GameObject.Find("Play Button").GetComponent<Button>().onClick.AddListener(delegate { startSingleplayerGame(); });
        }
        #endregion
    }

    void Update()
    {
        #region Game Functions
        CheckDueForBlock();
        #endregion

        #region MultyPlayer
        //Pass and Play
        testIfShouldShowSkips();

        if (GameData.selectedMode == GameMode.PassAndPlay)
        {

            updateTeamValues();
            testForSameColor();
            
        }

        if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerCoinText.text = GameData.team1coins.ToString();
        }
        #endregion
    }

    #region Multyplayer
    //public
    public void submitNamePannel()
    {
            //Team 1
            if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Player 1")
            {
                GameData.team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
                enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text = "";
                openNamePannel(2);
                changeTeamColor(1);
                team1ColorValue = pickAColorDropdown.value;
                //make player 2 color, a color behind player 1
                if (team1ColorValue != 0)
                {
                    pickAColorDropdown.value = team1ColorValue - 1;
                }
                else // if player 1 color is 0 then make player 2 color, 1
                {
                    pickAColorDropdown.value = 1;
                }

                currentTeamNumber = 2;
            }
            //Team 2
            else if (enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text == "Player 2")
            {
                GameData.team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
                enterNamePannel.SetActive(false);
                changeTeamColor(2);
                GameData.isGameOver = false;
                StartCoroutine(showNotificationPannel("Go first " + GameData.team1Name, 2));
                currentTeamNumber = 1;
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                GameData.isPlayerPlaying = true;
                GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
                spawner.GetComponent<shapeSpawner>().SpawnShape();
                if (CurrentData.gameData.isFirstTime && GameData.selectedMode == GameMode.PassAndPlay)
                {
                    GameObject.Find("Instructions Canvas").transform.GetChild(1).transform.gameObject.SetActive(true);
                    GameObject.Find("Objective Canvas").transform.GetChild(1).transform.gameObject.SetActive(true);
                    CurrentData.gameData.isFirstTime = false;
                }
            GameData.namesExist = true;
            }

    }

    //private
    void updateTeamValues()
    {
        //Set Values
        team1CoinText.text = GameData.team1coins.ToString();
        team2CoinText.text = GameData.team2coins.ToString();
    }
    void testForSameColor()
    {
        //Same Color Detection for enterNamePannel
        if ((enterNamePannel.activeInHierarchy == true) && currentTeamNumber == 2)
        {
            if ((team1ColorValue == pickAColorDropdown.value))
            {
                enterNamePannel.transform.Find("Pick a Color Text").GetComponent<Text>().text = "Pick a Different Color";
                submitButton.enabled = false;
            }
            else
            {
                enterNamePannel.transform.Find("Pick a Color Text").GetComponent<Text>().text = "Pick a Color";
                submitButton.enabled = true;
            }
        }
    }
    void testIfShouldShowSkips()
    {
        //When skips are zero then show buy skips
        if (currentTeamNumber == 1)
        {
            skipButtonText.text = "Skips Left: " + GameData.team1Skips;
            if (GameData.team1Skips == 0)
            {
                skipButton.enabled = false;
                buySkipButton.gameObject.SetActive(true);
                if (GameData.team1coins >= 3)
                {
                    buySkipButton.enabled = true;
                }
                else
                {
                    buySkipButton.enabled = false;
                }
            }
            else
            {
                skipButton.enabled = true;
                buySkipButton.gameObject.SetActive(false);
            }
        }
        else if (currentTeamNumber == 2)
        {
            skipButtonText.text = "Skips Left: " + GameData.team2Skips;
            if (GameData.team2Skips == 0)
            {
                skipButton.enabled = false;
                buySkipButton.gameObject.SetActive(true);
                if (GameData.team2coins >= 3)
                {
                    buySkipButton.enabled = true;
                }
                else
                {
                    buySkipButton.enabled = false;
                }
            }
            else
            {
                skipButton.enabled = true;
                buySkipButton.gameObject.SetActive(false);
            }
        }
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
        else if (teamNumber == 2)
        {
            enterNamePannel.transform.Find("Team 1 or 2").gameObject.GetComponent<Text>().text = "Player 2";
            team1Arrow.SetActive(false);
            team2Arrow.SetActive(true);
        }
    }
    void showNotificationPannel(string whatToSay, bool StayForever)
    {
        if (StayForever)
        {
            notificationPannelText.text = whatToSay;
            teamUIAnimator.SetBool("isNotificationPannelOpen", true);
        }
        else
        {
            teamUIAnimator.SetBool("isNotificationPannelOpen", false);
        }
    }
    void Turns()
    {
        if(!GameData.isGameOver){
            if (currentTeamNumber == 1)
            {
                team2Arrow.SetActive(true);
                team1Arrow.SetActive(false);
                StartCoroutine(showNotificationPannel("Your Turn, " + GameData.team2Name + "!", 2));
                currentTeamNumber = 2;
            }
            else if (currentTeamNumber == 2)
            {
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                StartCoroutine(showNotificationPannel("Your Turn, " + GameData.team1Name + "!", 2));
                currentTeamNumber = 1;
            }
            GameData.currentTeamNumber = currentTeamNumber;
            GameData.isPlayerPlaying = true;
            spawner.GetComponent<shapeSpawner>().SpawnShape();
        }
    }
    IEnumerator showNotificationPannel(string whatToSay, int waitTime)
    {
        notificationPannelText.text = whatToSay;
        teamUIAnimator.SetBool("isNotificationPannelOpen", true);
        yield return new WaitForSeconds(waitTime);
        teamUIAnimator.SetBool("isNotificationPannelOpen", false);
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
        if (teamNumber == 1)
        {
            team1Color = detectPlayerColorChoice();
            team1NameText.text = GameData.team1Name;
            team1Background.color = team1Color;
            GameData.team1Color = team1Color;

            //for team 2

        }
        else if (teamNumber == 2)
        {
            team2Color = detectPlayerColorChoice();
            team2NameText.text = GameData.team2Name;
            team2Background.color = team2Color;
            GameData.team2Color = team2Color;
        }
    }
    #endregion

    #region singleplayer
    void startSingleplayerGame()
    {
        currentTeamNumber = 1;
        singlePlayerObject.transform.Find("Instructions").gameObject.SetActive(false);
        GameData.isPlayerPlaying = true;
        GameData.isGameOver = false;
        GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
        GameData.team1Color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        spawner.GetComponent<shapeSpawner>().SpawnShape();
    }
    #endregion

    #region Game Functions
    IEnumerator placeBlockCountDown(int time)
    {
        GameData.isPlayerPlaying = false;
        #region countdown
        for (int i = time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
        }

        #endregion
        #region end of turn
        
        //Pass and Play
        if (GameData.selectedMode == GameMode.PassAndPlay)
        {
            if (currentTeamNumber == 1 && !GameData.isGameOver)
            {
                StartCoroutine(showNotificationPannel("Good Job " + GameData.team1Name, 2));
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(showNotificationPannel("Now go " + GameData.team2Name + "!", 2));
                Turns();
            }
            else if (currentTeamNumber == 2 && !GameData.isGameOver)
            {
                StartCoroutine(showNotificationPannel("Good Job " + GameData.team2Name, 2));
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(showNotificationPannel("Now go " + GameData.team1Name + "!", 2));
                Turns();

            } 
            //SinglePlayer
        }else if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            if (!GameData.isGameOver)
            {
                yield return new WaitForSeconds(waitTime);
                GameData.team1Color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                GameData.currentTeamNumber = 1;
                GameData.isPlayerPlaying = true;
                spawner.GetComponent<shapeSpawner>().SpawnShape();

            }
        }
        #endregion
    }

    // Update is called once per frame


    public void SpawnNewBlock()
    {
        if (GameData.isPlayerPlaying && GameData.canSpawnShape == true)
        {
            isDueForBlock = false;
            StartCoroutine(placeBlockCountDown(0));
        }
        else if (GameData.canSpawnShape == false)
        {
            isDueForBlock = true;
        }
    }

    void CheckDueForBlock()
    {
        if (isDueForBlock == true)
        {
            SpawnNewBlock();
        }
    }

    public void ChangeWaitTime()
    {
        waitTime = float.Parse(debugFeild.text);
    }
    #endregion


    public void nextBtnClick(){
        GameObject.Find("Singleplayer UI(Clone)").transform.Find("Objective").gameObject.SetActive(false);
    }

}

