using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUIPrefab;
    private AudioSource gameOverSound;

    private float totalScore = 0;
    private int lossCounter = 0;

    private ShapeMovement shapeMovementScript;

    private GameObject heightLine;
    private HeightLine heightLineScript;
    [SerializeField]
    private GameObject mainCamera;
    private CameraController camController;

    public GameObject newHighScoreText;

    private void Awake()
    {
        Getvaribles();
    }
    #region Gameover
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Create Game Over If 
        if (!DataBase.isGameOver)
        {
            if (collision.tag == "Block")
            {
                shapeMovementScript = collision.gameObject.GetComponent<ShapeMovement>();

                //real game over sequence
                if (shapeMovementScript.isFrozen == false)
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
                    gameOverUIPrefab.SetActive(true);
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

        GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: " + DataBase.blocksPlacedInGame;
        GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + DataBase.highScore;
    }

    void UpdateDataBase()
    {
        PlayerPrefs.SetInt("Total Blocks Lost", PlayerPrefs.GetInt("Total Blocks Lost") + lossCounter);
        DataBase.totalBlocksLost = PlayerPrefs.GetInt("Total Blocks Lost", lossCounter);
        DataBase.totalCoins += (DataBase.team1coins + DataBase.team2coins);

        if (totalScore > PlayerPrefs.GetFloat("High Score"))
        {
            DataBase.highScore = totalScore;
            PlayerPrefs.SetFloat("High Score", DataBase.highScore);
            newHighScoreText.SetActive(true);
        }

    }

    #endregion

    #region debugCheckFunctions
    void Getvaribles()
    {
        heightLine = GameObject.Find("HeightLine");
        heightLineScript = heightLine.GetComponent<HeightLine>();
        mainCamera = GameObject.Find("Main Camera");
        mainCamera = GameObject.FindGameObjectWithTag("Camera");
        camController = mainCamera.gameObject.GetComponent<CameraController>();
    }
    #endregion
}
