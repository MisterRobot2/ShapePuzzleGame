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


    // Use this for initialization
    void Start ()
    {
        GetVaribles();
        heightScript = heightLine.GetComponent<HeightLine>();
        initalHeight = heightScript.initalHeight;
        goalHeight += Random.Range(Mathf.Round(goalHeightMin),Mathf.Round(GoalHeightMax));

        SetLineHeight();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GoalMatch();
    }

    void SetLineHeight()
    {
        //Sets the position of the Line
        this.transform.position = heightLine.transform.position;
        transform.Translate(new Vector2(0, goalHeightIncrement));

        //Finds the height to display
        height = ((Mathf.Round((this.transform.position.y - initalHeight) * 10)) / 10);
        moveTextScript.UpdateText(height + "Ft");
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
        chiled.transform.localScale = (new Vector3((chiled.transform.localScale.x - platformCount/100), chiled.transform.localScale.y, chiled.transform.localScale.z));
        
        platformCount++;
        DataBase.firstGoalLine = true;
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
