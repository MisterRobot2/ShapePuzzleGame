using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeightLine : MonoBehaviour
{
    public float upSpeed = 0.1f;

    // Hiddin public varibles

    // Line movement
    [HideInInspector]
    public float initalHeight;
    [HideInInspector]
    public float height;

    //Private Varibles

    //tags
    private string blockTag = "Block";
    private string platformTag = "Platform";

    //Objects
    private TextMesh text;
    private GameObject Spawner;
    private MoveText moveTextScript;
    private float gameOverTriggerOffset = -10;
    private Text totalHeightText;

    //Camera movement
    private float heightTilMoveup = 5;
    private float maxhightTilMoveUp;
    private float currentMoveProgress = 0;

    //line movement
    [SerializeField]
    private List<GameObject> collidingObject;
    [SerializeField]
    private List<GameObject> collidingObjectHistory;
    
    private bool Freeze;
    private bool setToFreeze;
    private bool upSequence = false;
    private bool downSequence = false;


    private void Awake()
    {
        initalHeight = this.transform.position.y;
    }

    void Start ()
    {
        SetVaribles();
    }
	
	void Update ()
    {
        UpSequence();
        DownSequence();
        CalculateHeight();
	}

    #region debugCheckFunctions
    void SetVaribles()
    {
        GameObject totalHeightTextobject = GameObject.Find("Game Over");
        totalHeightTextobject.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        totalHeightText = GameObject.Find("New High Score Text").GetComponent<Text>();
        Spawner = GameObject.Find("Spawner");
        text = GameObject.Find("Height Text").GetComponent<TextMesh>();
        moveTextScript = text.GetComponent<MoveText>();
        totalHeightTextobject.gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }
    #endregion

    #region LineDetection

    //Trigger enter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            collidingObject.Add(other.gameObject);
            
            //If history dosnt contain currently collided objects Go Up
            foreach (var item in collidingObject)
            {
                if (!collidingObjectHistory.Contains(other.gameObject))
                {
                    Freeze = false;
                    collidingObjectHistory.Clear();
                    upSequence = true;
                    downSequence = false;
                }
            }

            //Freeze the object after colliding with self
            if (Freeze == false && setToFreeze == true)
            {
                foreach (var item in collidingObject)
                {
                    if (collidingObjectHistory.Contains(item) && setToFreeze == true)
                    {
                        Freeze = true;
                        setToFreeze = false;
                    }
                }
            }

            //go up if somthing is colliding with it
            if (collidingObject.Count != 0)
            {
                upSequence = true;
                downSequence = false;
            }

        }
    }

    //Stay colliding
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            if (collidingObject.Count != 0)
            {
                upSequence = true;
                downSequence = false;
            }

        }
        
    }

    //Exit colliding 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            // If not in history undo freeze and add it
            foreach (var item in collidingObject)
            {
                if (!collidingObjectHistory.Contains(other.gameObject))
                {
                    collidingObjectHistory.Add(other.gameObject);
                    Freeze = false;
                }
            }
            collidingObject.Remove(other.gameObject);

            // set to freeze it if colliding count is 0
            if (collidingObject.Count == 0 && Freeze == false)
            {
                downSequence = true;
                upSequence = false;
                setToFreeze = true;
            }

            if (collidingObject.Count == 0 && Freeze == true)
            {
                downSequence = true;
                upSequence = false;
                setToFreeze = false;
            }

            //Self detection after getting passed
            if (Freeze == true)
            {
                collidingObjectHistory.Clear();
                Freeze = false;
            }
            
        }
        
    }
  
    //Moves the line Up
    void UpSequence()
    {
        if (upSequence == true && Freeze == false && collidingObject.Count != 0)
        {
            transform.Translate(new Vector2(0, upSpeed));
            downSequence = false;
        }
       
    }

    //Moves the Line down
    void DownSequence()
    {
        if (downSequence == true && Freeze == false && collidingObject.Count == 0)
        {
            transform.Translate(new Vector2(0, -upSpeed));
            upSequence = false;
        }

        //Forces it to move down if frozen
        if (Freeze == true && collidingObject.Count == 0)
        {
            Freeze = false;
            downSequence = true;
        }
        
    }
    #endregion

    #region UpdateHeightText

    void CalculateHeight()
    {

        if (GameData.ScreenWidth >= 10)
        {
            height = (Mathf.Round((this.transform.position.y - initalHeight) * 10) / 10);
            moveTextScript.UpdateText(height + "Ft");
        }
        else
        {
            height = (Mathf.Round((this.transform.position.y / GameData.ScreenWidth * 10 - initalHeight / GameData.ScreenWidth * 10) * 10)) / 10;
            moveTextScript.UpdateText(height + "Ft");
        }
        moveTextScript.UpdateText(height + "Ft");
        text.text = height + "Ft";
        GameData.currentHeight = height; 
    }

    #endregion
}
