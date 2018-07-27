using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverUIPrefab;
    private AudioSource gameOverSound;
<<<<<<< HEAD
    private int totalScore = 0;
    private int lossCounter = 0;
=======
    private ShapeMovement shapeMovementScript;
<<<<<<< HEAD
    private GameObject heightLine;
    private HeightLine heightLineScript;
=======
>>>>>>> 7671b9fa843161f5ab9b9b10f0164c0b4532e7ac
>>>>>>> b3484f85711489bf8e2802be7954f3e477d2c68f

    void Start ()
    {
        DebugCheck();
        gameOverUIPrefab.SetActive(false);
        gameOverSound = gameOverUIPrefab.GetComponent<AudioSource>();
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        DataBase.score--;
        totalScore = PlayerPrefs.GetInt("Total Blocks Placed") + DataBase.score;
        lossCounter = PlayerPrefs.GetInt("Total Blocks Lost") + 1;
        //Create Game Over If 
        if (!DataBase.isGameOver)
        {
            DataBase.isGameOver = true;
            GameObject gameOverObject = Instantiate(gameOverUIPrefab);
            gameOverObject.name = "Game Over";
            //blocks placed text 
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: " + DataBase.score;
            if (DataBase.score > PlayerPrefs.GetInt("High Score"))
            {
                PlayerPrefs.SetInt("High Score", DataBase.score);
            }
            GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("High Score Text").GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High Score");
            PlayerPrefs.SetInt("Total Blocks Placed", totalScore);
            PlayerPrefs.SetInt("Total Blocks Lost", lossCounter);
=======
        if(collision.tag == "Block")
        {
            shapeMovementScript = collision.gameObject.GetComponent<ShapeMovement>();
>>>>>>> 7671b9fa843161f5ab9b9b10f0164c0b4532e7ac
        }
        
        if (collision.gameObject.tag == "Block" && shapeMovementScript.isFrozen == false)
        {
            DataBase.score--;
            //Create Game Over If 
            if (!DataBase.isGameOver)
            {
                DataBase.isGameOver = true;

                GameObject gameOverObject = Instantiate(gameOverUIPrefab);
                gameOverObject.name = "Game Over";
                //blocks placed text 
                GameObject.Find("Game Over").transform.Find("Game Over Panel").transform.Find("Blocks Placed Text").GetComponent<Text>().text = "Blocks Placed: " + DataBase.score;
                heightLineScript.moveDownSequence = true;
            }
            if (DataBase.isGameOver == true)
            {
                gameOverUIPrefab.SetActive(true);
                gameOverSound.Play();
                Time.timeScale = 0.3f;
            }
        }
        
    }

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
