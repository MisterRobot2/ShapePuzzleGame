using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeightLine : MonoBehaviour
{
    public bool moveDownSequence;

    public float upSpeed = 0.1f;

    // Hiddin public varibles

    // Line movement
    [HideInInspector]
    public float initalHeight;
    [HideInInspector]
    public float height;

    //tags
    [SerializeField]
    private string blockTag = "Block";
    [SerializeField]
    private string platformTag = "Platform";

    //Objects
    private TextMesh text;
    private GameObject Spawner;
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
    private bool isColliding = true;
    private bool Freeze;
    private bool upSequence;
    private bool downSequence;
    private GameObject topblock = null;
    private GameObject oldBlock = null;
    private ShapeMovement shapeMoveScript;
    private GameObject collidingObject;


    private void Awake()
    {
        initalHeight = this.transform.position.y;
    }

    void Start ()
    {
        upSequence = true;
        SetVaribles();
    }
	
	void FixedUpdate ()
    {
        UpSequence();
        DownSequence();
        CalculateHeight();
        GameOverTriggerFollow();
	}

    #region debugCheckFunctions
    void SetVaribles()
    {
        Spawner = GameObject.Find("Spawner");
        gameOverTrigger = GameObject.Find("GameOverTrigger");
        text = GameObject.Find("Height Text").GetComponent<TextMesh>();
        moveTextScript = text.GetComponent<MoveText>();

    }
    #endregion

    #region LineDetection

    //Trigger enter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            collidingObject = other.gameObject;

            if (topblock == other.gameObject && other.gameObject == oldBlock)
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

    //Stay colliding
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            collidingObject = other.gameObject;

            topblock = other.gameObject;
            isColliding = true;
        }
        
    }
    //Exit colliding 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == blockTag || other.gameObject.tag == platformTag)
        {
            oldBlock = other.gameObject;
            collidingObject = other.gameObject;

            isColliding = false;
            downSequence = true;
            if (topblock == other.gameObject)
            {
                Freeze = false;
            }
        }
        
    }
   

    void UpSequence()
    {
        if (upSequence == true )//&& collidingObject != null)
        {
            if (isColliding == true && Freeze == false)
            {
                /* if (collidingObject.tag == "Block")
                 {
                     if (collidingObject.GetComponent<ShapeMovement>().isFrozen == true)
                     {
                         transform.Translate(new Vector2(0, upSpeed));
                     }
                 }
                 else if(collidingObject.tag == "Platform")
                 {

                 }

                 transform.Translate(new Vector2(0, upSpeed));
                 */
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

    #region UpdateHeightText

    void CalculateHeight()
    {
        height = (Mathf.Round((this.transform.position.y - initalHeight) * 10)) / 10;
        moveTextScript.UpdateText(height + "Ft");
        text.text = height + "Ft";
    }

    #endregion
}
