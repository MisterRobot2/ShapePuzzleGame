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

    //Objects
    GameObject goalLine;
    GameObject heightLine;
    GoalLine goalLineScript;
    HeightLine HeightLineScript;

    

    // Use this for initialization
    void Start()
    {
        GetVaribles();
        initalHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveCameraUp();
        MoveCameraDown();
    }

    #region CameraMovement

    void moveCameraUp()
    {
        if (freeze == false && UpAmount > 0)
        {
            transform.Translate(new Vector2(0, Speed));
            UpAmount -= Speed;
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
