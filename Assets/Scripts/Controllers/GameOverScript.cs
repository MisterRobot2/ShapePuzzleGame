using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUIPrefab;
    [SerializeField]
    private AudioSource gameOverSound;
    [SerializeField]
    private bool forceGameOver;

    private float totalScore = 0;
    private int lossCounter = 0;

    private ShapeMovement shapeMovementScript;

    private GameObject heightLine;
    private HeightLine heightLineScript;
    [SerializeField]
    private GameObject mainCamera;
    private CameraController camController;

    public Text newHighScoreText;
    public Text highScoreText;
    public Text highScoreWords;

    public GameObject tryHarderText; // Text for tutorial


    private string winner;


    private void Awake()
    {
        Getvaribles();
    }
    #region Gameover
    private void OnTriggerEnter2D(Collider2D collision)
    {
        shapeMovementScript = collision.gameObject.GetComponent<ShapeMovement>();

        if (DataBase.isTutorial == true && collision.gameObject.tag == "Block" && shapeMovementScript.isFrozen == false)
        {
            StartCoroutine(ShowMessage());
        }

        //Create Game Over If 
       else if (!DataBase.isGameOver)
        {
            if (collision.tag == "Block")
            {
                //real game over sequence
                if (shapeMovementScript.isFrozen == false && DataBase.canGameOver == true)
                {
                    lossCounter++;
                    DataBase.canSpawnShape = false;
                    totalScore = heightLineScript.height;
                    DataBase.totalBlocksPlaced = DataBase.totalBlocksPlaced + DataBase.blocksPlacedInGame;
                    PlayerPrefs.SetInt("Total Blocks Placed", PlayerPrefs.GetInt("Total Blocks Placed") + DataBase.blocksPlacedInGame);
                    

                    SetGameOverVaribles();
                    UpdateDataBase();
                    
                }
                if (forceGameOver == true && shapeMovementScript.isFrozen == false)
                {
                    lossCounter++;
                    DataBase.canSpawnShape = false;
                    totalScore = heightLineScript.height;
                    DataBase.totalBlocksPlaced = DataBase.totalBlocksPlaced + DataBase.blocksPlacedInGame;
                    PlayerPrefs.SetInt("Total Blocks Placed", PlayerPrefs.GetInt("Total Blocks Placed") + DataBase.blocksPlacedInGame);


                    SetGameOverVaribles();
                    UpdateDataBase();
                }
            }

            if (collision.gameObject.tag == "Block" && shapeMovementScript.isFrozen == false)
            {
                if (DataBase.isGameOver == true)
                {
                    gameOverUIPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    gameOverSound = gameOverUIPrefab.GetComponent<AudioSource>();
                    gameOverSound.Play();
                    DataBase.gameSpeed = 0.3f;
                    DataBase.freezeGameSpeed = true;
                }
            }

        }
    }

    void SetGameOverVaribles()
    {
        DataBase.isGameOver = true;
        camController.goDown = true;

        if (DataBase.currentTeamNumber == 1)
        {
            winner = DataBase.team2Name;
        }
        else if (DataBase.currentTeamNumber == 2)
        {
            winner = DataBase.team1Name;
        }

        if(DataBase.selectedMode == GameMode.SinglePlayer)
        {
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: <color=#d1e53bff><b>" + DataBase.blocksPlacedInGame+"</b></color>";
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + "<color=#d1e53bff><b>" + DataBase.highScore + "</b></color>";
        }
        else if(DataBase.selectedMode == GameMode.PassAndPlay)
        {
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Winner Text").GetComponent<Text>().text = winner + " Wins!";
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + "<color=#d1e53bff><b>" + DataBase.highScore+"</b></color>";
        }
        
    }

    void UpdateDataBase()
    {
        PlayerPrefs.SetInt("Total Blocks Lost", PlayerPrefs.GetInt("Total Blocks Lost") + lossCounter);
        DataBase.totalBlocksLost = PlayerPrefs.GetInt("Total Blocks Lost", lossCounter);
        DataBase.totalCoins += (DataBase.team1coins + DataBase.team2coins);
        DataBase.highScore = PlayerPrefs.GetFloat("High Score");

        //Updates the words of your score
        if (DataBase.currentHeight <= 1)
        {
            highScoreWords.GetComponent<Text>().text = "How Did you lose with " + DataBase.currentHeight + "Ft " + " Are you even trying?";
        }
        else
        {
            highScoreWords.GetComponent<Text>().text = "<color=#d1e53bff><b>" + "You Reached: " + DataBase.currentHeight + " Ft!" + "</b></color>";
        }


        if (totalScore > PlayerPrefs.GetFloat("High Score"))
        {
            DataBase.highScore = totalScore;
            PlayerPrefs.SetFloat("High Score", DataBase.highScore);
            newHighScoreText.gameObject.SetActive(true);
        }
        else
        {
            newHighScoreText.gameObject.SetActive(false);
        }
        highScoreText.GetComponent<Text>().text = "High Score: " + DataBase.highScore + " Ft!";


    }


    #endregion

    #region debugCheckFunctions
    void Getvaribles()
    {
        gameOverUIPrefab = GameObject.Find("Game Over");
        gameOverUIPrefab.transform.GetChild(0).gameObject.SetActive(true);
        heightLine = GameObject.Find("HeightLine");
        heightLineScript = heightLine.GetComponent<HeightLine>();
        mainCamera = GameObject.Find("Main Camera");
        mainCamera = GameObject.FindGameObjectWithTag("Camera");
        camController = mainCamera.gameObject.GetComponent<CameraController>();
        highScoreWords = GameObject.Find("Blocks Placed Text").GetComponent<Text>();
        highScoreText = GameObject.Find("High Score Text").GetComponent<Text>();
        newHighScoreText = GameObject.Find("New High Score Text").GetComponent<Text>();
        gameOverUIPrefab.transform.GetChild(0).gameObject.SetActive(false);

    }
    #endregion

    IEnumerator ShowMessage()
    {
        tryHarderText.SetActive(true);
        yield return new WaitForSeconds(3);
        tryHarderText.SetActive(false);
    }
}
