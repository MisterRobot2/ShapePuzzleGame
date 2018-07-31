﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeightLine : MonoBehaviour
{
    public bool moveDownSequence;

    [SerializeField]
    private float upSpeed = 0.1f;

    //tags
    [SerializeField]
    private string blockTag = "Block";
    [SerializeField]
    private string platformTag = "Platform";

    //Objects
    private TextMesh text;
    private GameObject Spawner;
    private GameObject mainCamera;
    private MoveText moveTextScript;
    [SerializeField]
    private GameObject gameOverTrigger;

    //GameOverTrigger
    [SerializeField]
    private float gameOverTriggerOffset = -5;
    [SerializeField]
    private Text totalHeightText;

    //Camera movement
    private float heightTilMoveup = 5;
    private float maxhightTilMoveUp;
    private float currentMoveProgress = 0;
    
    //line movement
    [HideInInspector]
    public float initalHeight;
    [HideInInspector]
    public float height;
    private bool isColliding = true;
    private bool Freeze;
    private bool upSequence;
    private bool downSequence;
    private GameObject topblock = null;


    private void Awake()
    {
        initalHeight = this.transform.position.y;
    }

    void Start ()
    {
        upSequence = true;
        DebugCheck();
    }
	
	void FixedUpdate ()
    {
        UpSequence();
        DownSequence();
        MoveCameraUp();
        MoveCameraDown();
        CalculateHeight();
        GameOverTriggerFollow();
	}

    

    #region debugCheckFunctions
    void DebugCheck()
    {

        Spawner = GameObject.Find("Spawner");
        mainCamera = GameObject.Find("Main Camera");
        gameOverTrigger = GameObject.Find("GameOverTrigger");
        text = GameObject.Find("Height Text").GetComponent<TextMesh>();
        moveTextScript = text.GetComponent<MoveText>();


        if (Spawner == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'Spawner' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (mainCamera == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'Main Camera' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (text == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'Main Camera' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (gameOverTrigger == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'GameOverTrigger' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (moveTextScript == null)
        {
            Debug.LogWarning(this.gameObject.name + " please make sure that the MoveText component is on it");
        }
    }
    #endregion

    #region LineDetection
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == blockTag || collision.gameObject.tag == platformTag)
        {
            topblock = collision.gameObject;
            isColliding = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == blockTag || collision.gameObject.tag == platformTag)
        {
            isColliding = false;
            downSequence = true;
            if (topblock == collision.gameObject)
            {
                Freeze = false;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            if (topblock == other.gameObject)
            {
                Freeze = true;
            }
            else
            {
                Freeze = false;
            }
            upSequence = true;
        }
        
    }

    void UpSequence()
    {
        if (upSequence == true)
        {
            if (isColliding == true && Freeze == false)
            {
                transform.Translate(new Vector2(0, upSpeed));
            }
        }
    }
    void DownSequence()
    {
        if (downSequence == true)
        {
            if (isColliding == false && Freeze == false)
            {
                transform.Translate(new Vector2(0, -upSpeed));
            }
        }
    }
    #endregion

    #region GameOverCollider

    void GameOverTriggerFollow()
    {
        gameOverTrigger.transform.position = (new Vector2(this.transform.position.x, this.transform.position.y + gameOverTriggerOffset));
        if (height <= 0)
        {
            totalHeightText.text = "How Did you lose with " + height + "Ft "+" Are you even trying?";
        }
        else
        {
            totalHeightText.text = "You Reached " + height + "Ft!";
        }
        
    }

    #endregion

    #region Camera movement
    void CalculateHeight()
    {
        height = (Mathf.Round((this.transform.position.y - initalHeight)*10))/10;
        moveTextScript.UpdateText(height + "Ft");
        text.text = height + "Ft";
    }

    void MoveCameraUp()
    {
        if (moveDownSequence == false)
        {
            if (heightTilMoveup + maxhightTilMoveUp - height <= 0)
            {
                mainCamera.transform.Translate(new Vector2(0, +upSpeed));
                Spawner.transform.Translate(new Vector2(0, +upSpeed));
                currentMoveProgress += upSpeed;

            }

            if (currentMoveProgress >= 5) // set move up
            {
                heightTilMoveup = 5;
                maxhightTilMoveUp += 5;
                currentMoveProgress = 0;
            }
        }
    }

    void MoveCameraDown()
    {
        if (moveDownSequence == true)
        {
            if (moveDownSequence == true && (maxhightTilMoveUp != 0))// set move down
            {
                mainCamera.transform.Translate(new Vector2(0, -upSpeed));
                Spawner.transform.Translate(new Vector2(0, -upSpeed));

                maxhightTilMoveUp -= upSpeed;

            }

            if (maxhightTilMoveUp <= 0) // set move up
            {
                heightTilMoveup = 5;
                currentMoveProgress = 0;
                maxhightTilMoveUp = 0;
            }
        }
    }
    #endregion
}
