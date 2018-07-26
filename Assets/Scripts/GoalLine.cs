using UnityEngine;

public class GoalLine : MonoBehaviour
{
    //objects
    private TextMesh text;
    private HeightLine heightScript;
    private MoveText moveTextScript;
    private GameObject heightLine;

    //Goal height values
    [SerializeField]
    private float GoalHeightMax = 10;
    [SerializeField]
    private float goalHeightMin = 0;

    private float goalHeightIncrement = 5;
    private float goalHeight;
    
    private float initalHeight;
    private float height;


    // Use this for initialization
    void Start ()
    {
        DebugCheck();
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

    void GoalMatch()
    {
        //Detects when Goal is met :D 
        if (heightScript.height >= height)
        {
            goalHeightIncrement = Random.Range(Mathf.Round(goalHeightMin), Mathf.Round(GoalHeightMax));
            goalHeight += goalHeightIncrement;
            SetLineHeight();
        }
    }

    #region debugCheckFunctions
    void DebugCheck()
    {
        heightLine = GameObject.Find("HeightLine");
        text = GameObject.Find("Goal Text").GetComponent<TextMesh>();
        moveTextScript = text.GetComponent<MoveText>();

        if (heightLine == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'HeightLine' in scene, Please Make sure you name it correctly or change the name in the script.");
        }

        if (text == null)
        {
            Debug.LogWarning(this.gameObject.name + " Cant find refrence Of: 'Goal Text' in scene, Please Make sure you name it correctly or change the name in the script.");
        }
        if (moveTextScript == null)
        {
            Debug.LogWarning(this.gameObject.name + " please make sure that the MoveText component is on it");
        }
    }
    #endregion
}
