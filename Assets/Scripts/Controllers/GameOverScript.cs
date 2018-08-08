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

        if (GameData.isTutorial == true && collision.gameObject.tag == "Block" && shapeMovementScript.isFrozen == false)
        {
            StartCoroutine(ShowMessage());
        }

        //Create Game Over If 
       else if (!GameData.isGameOver)
        {
            if (collision.tag == "Block")
            {
                //real game over sequence
                if (shapeMovementScript.isFrozen == false && GameData.canGameOver == true)
                {
                    Debug.Log("gameover");
                    lossCounter++;
                    GameData.canSpawnShape = false;
                    totalScore = heightLineScript.height;
                    CurrentData.gameData.totalBlocksPlaced += GameData.blocksPlacedInGame;

                    SetGameOverVaribles();
                    UpdateDataBase();
                    
                }
                if (forceGameOver == true && shapeMovementScript.isFrozen == false)
                {
                    Debug.Log("Fgameover");
                    lossCounter++;
                    GameData.canSpawnShape = false;
                    totalScore = heightLineScript.height;
                    CurrentData.gameData.totalBlocksPlaced += GameData.blocksPlacedInGame;


                    SetGameOverVaribles();
                    UpdateDataBase();
                }
            }

            if (collision.gameObject.tag == "Block" && shapeMovementScript.isFrozen == false)
            {
                if (GameData.isGameOver == true)
                {
                    gameOverUIPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    gameOverSound = gameOverUIPrefab.GetComponent<AudioSource>();
                    gameOverSound.Play();
                    GameData.gameSpeed = 0.3f;
                    GameData.freezeGameSpeed = true;
                }
            }

        }
    }

    void SetGameOverVaribles()
    {
        GameData.isGameOver = true;
        camController.goDown = true;

        if (GameData.currentTeamNumber == 1)
        {
            winner = GameData.team2Name;
        }
        else if (GameData.currentTeamNumber == 2)
        {
            winner = GameData.team1Name;
        }

        if(GameData.selectedMode == GameMode.SinglePlayer)
        {
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Winner Text").GetComponent<Text>().text = "Blocks Placed: " + GameData.blocksPlacedInGame;
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + "<color=#d1e53bff>" + CurrentData.gameData.highScore + "</color>";
        }
        else if(GameData.selectedMode == GameMode.PassAndPlay)
        {
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Winner Text").GetComponent<Text>().text = winner + " Wins!";
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + "<color=#d1e53bff><b>" + CurrentData.gameData.highScore+"</b></color>";
        }
        
    }

    void UpdateDataBase()
    {
        CurrentData.gameData.totalBlocksLost += lossCounter;
        CurrentData.gameData.totalCoins += (GameData.team1coins + GameData.team2coins);

        //Updates the words of your score
        if (GameData.currentHeight <= 1)
        {
            highScoreWords.GetComponent<Text>().text = "<color=#d1e53bff>How Did you lose with " + GameData.currentHeight + "Ft " + " Are you even trying?</color>";
        }
        else
        {
            highScoreWords.GetComponent<Text>().text = "<color=#d1e53bff>" + "You Reached: " + GameData.currentHeight + " Ft!" + "</color>";
        }


        if (totalScore > CurrentData.gameData.highScore)
        {
            CurrentData.gameData.highScore = totalScore;
            newHighScoreText.gameObject.SetActive(true);
        }
        else
        {
            newHighScoreText.gameObject.SetActive(false);
        }
        highScoreText.GetComponent<Text>().text = "High Score: " + CurrentData.gameData.highScore + " Ft!";


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
