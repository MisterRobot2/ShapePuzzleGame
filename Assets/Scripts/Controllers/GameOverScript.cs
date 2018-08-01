using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUIPrefab;
    private AudioSource gameOverSound;

    private int totalScore = 0;
    private int lossCounter = 0;

    private ShapeMovement shapeMovementScript;

    private GameObject heightLine;
    private HeightLine heightLineScript;
    [SerializeField]
    private GameObject mainCamera;
    private CameraController camController;


    void Start()
    {
        
        
    }

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
                    totalScore = Mathf.RoundToInt(heightLineScript.height);
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
                    Time.timeScale = 0.3f;
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
        //High score
        if (heightLineScript.height >= totalScore)
        {
            DataBase.highScore = heightLineScript.height;
        }


        PlayerPrefs.SetInt("Total Blocks Lost", PlayerPrefs.GetInt("Total Blocks Lost") + lossCounter);
        DataBase.totalBlocksLost = PlayerPrefs.GetInt("Total Blocks Lost", lossCounter);

        if (DataBase.totalScore >= PlayerPrefs.GetInt("High Score"))
        {
            DataBase.highScore = DataBase.totalScore;
            PlayerPrefs.SetFloat("High Score", DataBase.highScore); 
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
