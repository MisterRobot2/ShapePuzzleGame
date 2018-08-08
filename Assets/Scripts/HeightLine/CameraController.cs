using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool goDown;
    private bool freeze;

    [SerializeField]
    bool isGoingUp;

    //Upsequence
    bool iscolliding = false;

    float Speed;
    float initalHeight;
    public float UpAmount;
    private float oldPos;

    //Objects
    GameObject goalLine;
    GameObject heightLine;
    GoalLine goalLineScript;
    HeightLine HeightLineScript;

    public GameObject background;


    //game over trigger setup
    public int numOfPlatforms;
    public GameObject newestPlatform;
    public float newestPlatformPosition;
    public GameObject gameOverTrigger;
    public GameObject forceGameOverTrigger;



    // Use this for initialization
    void Start()
    {
        GetVaribles();
        initalHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oldPos = this.transform.position.y;
        moveCameraUp();
        MoveCameraDown();
        CheckPosition();
    }

    #region CameraMovement

    void moveCameraUp()
    {
        if (freeze == false && UpAmount > 0)
        {
            transform.Translate(new Vector2(0, Speed));
            background.transform.localPosition = new Vector3(0.0f, background.transform.localPosition.y + Speed, 0.0f);
            UpAmount -= Speed;
            GameData.canGameOver = false;

            //setting up game over trigger
            numOfPlatforms = GameObject.Find("Platforms").transform.childCount;
            newestPlatform = GameObject.Find("Platforms").transform.GetChild(numOfPlatforms - 1).gameObject;

            if (numOfPlatforms == 1)
            {
                newestPlatformPosition = 0;
            }
            else
            {
                newestPlatformPosition = newestPlatform.transform.Find("PlatformFlyIn").transform.position.y;
            }
            Debug.Log(newestPlatformPosition);

            gameOverTrigger = GameObject.Find("GameOverTrigger").transform.gameObject;
            gameOverTrigger.transform.position = new Vector3(0, newestPlatformPosition-2, 0);

            forceGameOverTrigger = GameObject.Find("ForceGameOverTrigger").transform.gameObject;
            forceGameOverTrigger.transform.position = new Vector3(0, newestPlatformPosition-12, 0);

            //end setting up game over trigger


        }
        else if (UpAmount <= 0)
        {
            GameData.canGameOver = true;
        }
    }

    void MoveCameraDown()
    {
        if (goDown == true)
        {
            if (this.transform.position.y >= initalHeight)
            {
                transform.Translate(new Vector2(0, -Speed*2));
                freeze = true;
            }
        }
    }


    #endregion

    #region Block spawn Check
    void CheckPosition()
    {
        if (oldPos != this.transform.position.y)
        {
            GameData.canSpawnShape = false;
        }
        else if(oldPos == this.transform.position.y)
        {
            GameData.canSpawnShape = true;
        }
    }
    #endregion

    #region DebugCheck

    void GetVaribles()
    {
        goalLine = GameObject.Find("GoalLine");
        heightLine = GameObject.Find("HeightLine");
        HeightLineScript = heightLine.GetComponent<HeightLine>();
        goalLineScript = goalLine.GetComponent<GoalLine>();
        Speed = HeightLineScript.upSpeed;

    }

    #endregion
}
