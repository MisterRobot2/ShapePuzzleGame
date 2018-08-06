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
        if(DataBase.selectedMode == GameMode.PassAndPlay)
        {
            teamUIObject = Instantiate(teamUIPrefab);
            teamUIObject.transform.position = Vector3.zero;
        }
        //Singleplayer
        if(DataBase.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerObject = Instantiate(singlePlayerPrefab);
            singlePlayerObject.transform.position = Vector3.zero;
        }
        #endregion

        #region Get Objects
        //Pass and Play
        if(DataBase.selectedMode == GameMode.PassAndPlay)
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
        if(DataBase.selectedMode == GameMode.SinglePlayer)
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
        if(DataBase.selectedMode == GameMode.PassAndPlay)
        {
            team1Arrow.SetActive(false);
            team2Arrow.SetActive(false);
            enterNamePannel.SetActive(false);
            submitButton.onClick.AddListener(delegate { submitNamePannel(); });
        }

        //Game Setup
        buySkipButton.gameObject.SetActive(false);
        DataBase.blocksPlacedInGame = 0;
        DataBase.isGameOver = true;
        DataBase.team1Skips = 3;
        DataBase.team2Skips = 3;
        #endregion

        #region Start Game
        //Pass and Play
        //WORKING HERE
        if (DataBase.selectedMode == GameMode.PassAndPlay)
        {
            if(DataBase.namesExist){
                currentTeamNumber = 1;
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                team1NameText.text = DataBase.team1Name;
                team1Background.color = DataBase.team1Color;
                team2NameText.text = DataBase.team2Name;
                team2Background.color = DataBase.team2Color;
                DataBase.isPlayerPlaying = true;
                DataBase.isGameOver = false;
                GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
                spawner.GetComponent<shapeSpawner>().SpawnShape();
            } else{
                openNamePannel(1);
            }

        }
        //SinglePlayer
        if(DataBase.selectedMode == GameMode.SinglePlayer)
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

        if (DataBase.selectedMode == GameMode.PassAndPlay)
        {

            updateTeamValues();
            testForSameColor();
            
        }

        if(DataBase.selectedMode == GameMode.SinglePlayer)
        {
            singlePlayerCoinText.text = DataBase.team1coins.ToString();
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
                DataBase.team1Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
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
                DataBase.team2Name = enterNamePannel.transform.Find("enterNameInputField").GetComponent<TMP_InputField>().text;
                enterNamePannel.SetActive(false);
                changeTeamColor(2);
                DataBase.isGameOver = false;
                StartCoroutine(showNotificationPannel("Go first " + DataBase.team1Name, 2));
                currentTeamNumber = 1;
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                DataBase.isPlayerPlaying = true;
                GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
                spawner.GetComponent<shapeSpawner>().SpawnShape();
                if (DataBase.isFirstTime && DataBase.selectedMode == GameMode.PassAndPlay)
                {
                    GameObject.Find("Instructions Canvas").transform.GetChild(1).transform.gameObject.SetActive(true);
                    DataBase.isFirstTime = false;
                }
                DataBase.namesExist = true;
            }

    }

    //private
    void updateTeamValues()
    {
        //Set Values
        team1CoinText.text = DataBase.team1coins.ToString();
        team2CoinText.text = DataBase.team2coins.ToString();
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
            skipButtonText.text = "Skips Left: " + DataBase.team1Skips;
            if (DataBase.team1Skips == 0)
            {
                skipButton.enabled = false;
                buySkipButton.gameObject.SetActive(true);
                if (DataBase.team1coins >= 3)
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
            skipButtonText.text = "Skips Left: " + DataBase.team2Skips;
            if (DataBase.team2Skips == 0)
            {
                skipButton.enabled = false;
                buySkipButton.gameObject.SetActive(true);
                if (DataBase.team2coins >= 3)
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
        if(!DataBase.isGameOver){
            if (currentTeamNumber == 1)
            {
                team2Arrow.SetActive(true);
                team1Arrow.SetActive(false);
                StartCoroutine(showNotificationPannel("Your Turn, " + DataBase.team2Name + "!", 2));
                currentTeamNumber = 2;
            }
            else if (currentTeamNumber == 2)
            {
                team1Arrow.SetActive(true);
                team2Arrow.SetActive(false);
                StartCoroutine(showNotificationPannel("Your Turn, " + DataBase.team1Name + "!", 2));
                currentTeamNumber = 1;
            }
            DataBase.currentTeamNumber = currentTeamNumber;
            DataBase.isPlayerPlaying = true;
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
            team1NameText.text = DataBase.team1Name;
            team1Background.color = team1Color;
            DataBase.team1Color = team1Color;

            //for team 2

        }
        else if (teamNumber == 2)
        {
            team2Color = detectPlayerColorChoice();
            team2NameText.text = DataBase.team2Name;
            team2Background.color = team2Color;
            DataBase.team2Color = team2Color;
        }
    }
    #endregion

    #region singleplayer
    void startSingleplayerGame()
    {
        currentTeamNumber = 1;
        singlePlayerObject.transform.Find("Instructions").gameObject.SetActive(false);
        DataBase.isPlayerPlaying = true;
        DataBase.isGameOver = false;
        GameObject.FindGameObjectWithTag("ShapePreview").GetComponent<shapePreview>().SpawnFirstShape();
        DataBase.team1Color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        spawner.GetComponent<shapeSpawner>().SpawnShape();
    }
    #endregion

    #region Game Functions
    IEnumerator placeBlockCountDown(int time)
    {
        DataBase.isPlayerPlaying = false;
        #region countdown
        for (int i = time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
        }

        #endregion
        #region end of turn
        
        //Pass and Play
        if (DataBase.selectedMode == GameMode.PassAndPlay)
        {
            if (currentTeamNumber == 1 && !DataBase.isGameOver)
            {
                StartCoroutine(showNotificationPannel("Good Job " + DataBase.team1Name, 2));
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(showNotificationPannel("Now go " + DataBase.team2Name + "!", 2));
                Turns();
            }
            else if (currentTeamNumber == 2 && !DataBase.isGameOver)
            {
                StartCoroutine(showNotificationPannel("Good Job " + DataBase.team2Name, 2));
                yield return new WaitForSeconds(waitTime);
                StartCoroutine(showNotificationPannel("Now go " + DataBase.team1Name + "!", 2));
                Turns();

            } 
            //SinglePlayer
        }else if(DataBase.selectedMode == GameMode.SinglePlayer)
        {
            if (!DataBase.isGameOver)
            {
                yield return new WaitForSeconds(waitTime);
                DataBase.team1Color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
                DataBase.currentTeamNumber = 1;
                DataBase.isPlayerPlaying = true;
                spawner.GetComponent<shapeSpawner>().SpawnShape();

            }
        }
        #endregion
    }

    // Update is called once per frame


    public void SpawnNewBlock()
    {
        if (DataBase.isPlayerPlaying && DataBase.canSpawnShape == true)
        {
            isDueForBlock = false;
            StartCoroutine(placeBlockCountDown(0));
        }
        else if (DataBase.canSpawnShape == false)
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


}
