using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightLine : MonoBehaviour
{
    public bool moveDownSequence;

    [SerializeField]
    private float upSpeed = 0.1f;

    

    //Objects
      [SerializeField]
    private TextMesh text;
    private GameObject Spawner;
    private GameObject mainCamera;

    //Camera movement
    private float heightTilMoveup = 5;
    private float maxhightTilMoveUp;
    private float currentMoveProgress = 0;
    
    //line movement
    private float initalHeight;
    private float Height;
    private bool isColliding = true;
    private bool Freeze;
    private bool upSequence;
    private bool downSequence;
    private GameObject topblock = null;
    
    
	void Start ()
    {
        upSequence = true;
        initalHeight = this.transform.position.y;

        Spawner = GameObject.Find("Spawner");
        mainCamera = GameObject.Find("Main Camera");
    }
	
	void Update ()
    {
        if (upSequence == true)
        {    
            if (isColliding == true && Freeze == false)
            {
                transform.Translate(new Vector2(0, upSpeed));
            }
        }

        if (downSequence == true)
        {  
            if (isColliding == false && Freeze == false)
            {
                transform.Translate(new Vector2(0, -upSpeed));
            }
        }

        MoveCameraUp();
        MoveCameraDown();
        CalculateHeight();
	}

    #region LineDetection
    private void OnTriggerStay2D(Collider2D collision)
    {
        topblock = collision.gameObject;
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
        downSequence = true;
        if (topblock == collision.gameObject)
        {
            Freeze = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
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
    #endregion 

    #region Camera movement
    void CalculateHeight()
    {
        Height = (Mathf.Round((this.transform.position.y - initalHeight)*10))/10;
        text.text = Height + "Ft";
    }

    void MoveCameraUp()
    {
        if (moveDownSequence == false)
        {
            if (heightTilMoveup + maxhightTilMoveUp - Height <= 0)
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
