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


    void Start()
    {
        DebugCheck();
        gameOverUIPrefab.SetActive(false);
        gameOverSound = gameOverUIPrefab.GetComponent<AudioSource>();
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
                    gameOverSound.Play();
                    Time.timeScale = 0.3f;
                }
            }

        }
    }

    void SetGameOverVaribles()
    {
        DataBase.isGameOver = true;
        heightLineScript.moveDownSequence = true;

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
    void DebugCheck()
    {
        heightLine = GameObject.Find("HeightLine");
        heightLineScript = heightLine.GetComponent<HeightLine>();

        if (heightLine == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'HeightLine' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (heightLineScript == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'HeightLine' in HeightLine, Please Make sure you attacjh the component or change the name in the script.");
        }
    }
    #endregion
}
