using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    //objects
    [SerializeField]
    private GameObject platform;
    private TextMesh text;
    private HeightLine heightScript;
    private MoveText moveTextScript;
    private GameObject heightLine;
    [SerializeField]
    private GameObject parent;
    
    //Platforms
    private float platformCount;

    //Goal height values
    [SerializeField]
    private float GoalHeightMax = 10;
    [SerializeField]
    private float goalHeightMin = 0;

    private float goalHeightIncrement = 5;
    private float goalHeight;
    
    private float initalHeight;
    public float height;


    //game over trigger setup
    public int numOfPlatforms;
    public GameObject newestPlatform;
    public float newestPlatformPosition;
    public GameObject gameOverTrigger;
    public GameObject forceGameOverTrigger;



    // Use this for initialization
    void Start ()
    {
        GetVaribles();
        heightScript = heightLine.GetComponent<HeightLine>();
        initalHeight = heightScript.initalHeight;
        goalHeight += Random.Range(Mathf.Round(goalHeightMin),Mathf.Round(GoalHeightMax));

        if (GameData.ScreenWidth >= 10)
        {
            goalHeight += Random.Range(Mathf.Round(goalHeightMin), Mathf.Round(GoalHeightMax));
        }
        else
        {
            goalHeight += Random.Range(Mathf.Round(goalHeightMin/ GameData.ScreenWidth), Mathf.Round(GameData.ScreenWidth));
        }

        SetLineHeight();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GoalMatch();
        moveTextScript.UpdateText(height + "Ft");

    }

    void SetLineHeight()
    {
        //Sets the position of the Line
        this.transform.position = heightLine.transform.position;
        

        //Finds the height to display
        if (GameData.ScreenWidth >= 10)
        {
            transform.Translate(new Vector2(0, goalHeightIncrement));
            height = (Mathf.Round((this.transform.position.y - initalHeight) * 10) / 10);
        }
        else
        {
            transform.Translate(new Vector2(0, goalHeightIncrement / GameData.ScreenWidth* 3.333f));
            height = ((Mathf.Round(((this.transform.position.y / GameData.ScreenWidth * 10) - (initalHeight / GameData.ScreenWidth * 10)) * 10)) / 10);
            moveTextScript.UpdateText(height + "Ft");
        }
        text.text = height+ "Ft";
    }
    #region GoalMatch
    void GoalMatch()
    {
        //Detects when Goal is met :D 
        if (heightScript.height >= height)
        {
            StartCoroutine(GoalLineDelay());
            
        }
    }

    IEnumerator GoalLineDelay()
    {
        yield return new WaitForSeconds(.75f);
        if (heightScript.height >= height)
        {
            goalHeightIncrement = Random.Range(Mathf.Round(goalHeightMin), Mathf.Round(GoalHeightMax));
            goalHeight += goalHeightIncrement;
            SetLineHeight();

            MakePlatforms();
        }
        
    }

    void MakePlatforms()
    {
        GameObject spawnedPlatform = Instantiate(platform, parent.transform);
        GameObject chiled = spawnedPlatform.transform.GetChild(0).gameObject;
        chiled.transform.position = (new Vector2(0, heightLine.transform.position.y+.25f));
        chiled.transform.localScale = (new Vector3((chiled.transform.localScale.x - platformCount*1), chiled.transform.localScale.y, chiled.transform.localScale.z));
        
        platformCount++;
        GameData.firstGoalLine = true;

        StartCoroutine(moveTriggerDelay());

    }


    IEnumerator moveTriggerDelay()
    {
        yield return new WaitForSeconds(2f);

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

        gameOverTrigger = GameObject.Find("GameOverTrigger").transform.gameObject;
        gameOverTrigger.transform.position = new Vector3(0, newestPlatformPosition - 2, 0);

        forceGameOverTrigger = GameObject.Find("ForceGameOverTrigger").transform.gameObject;
        forceGameOverTrigger.transform.position = new Vector3(0, newestPlatformPosition - 12, 0);

        //end setting up game over trigger

    }
    #endregion

    #region debugCheckFunctions
    void GetVaribles()
    {
        heightLine = GameObject.Find("HeightLine");
        text = GameObject.Find("Goal Text").GetComponent<TextMesh>();
        moveTextScript = text.GetComponent<MoveText>();

    }
    #endregion
}
