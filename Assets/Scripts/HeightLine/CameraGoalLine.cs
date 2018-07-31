using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraGoalLine : MonoBehaviour
{
    [SerializeField]
    private bool showLine;
    [SerializeField]
    private float UpAmount;

    private float lineheight;

    //objects
    private CameraController camcontroller;
    private GameObject mainCamera;
    private Image texture;
    private GameObject textureObj;
    private GameObject textObj;
    private TextMesh text;

    private void Start()
    {
        SetVaribles();
        this.transform.position = Vector2.zero;
        this.transform.Translate(new Vector2(0, lineheight+UpAmount));
        text.text = this.transform.position.y + "FT";
    }

    private void Update()
    {
        HideLine();
    }

    //moves the camera up if the height line collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GoalLine")
        {
            camcontroller.UpAmount += UpAmount;
            lineheight += UpAmount;
            this.transform.Translate(new Vector2(0, UpAmount));  
        }
    }

    
    void UpdateText()
    {
        if (showLine == true)
        {
            text.text = this.transform.position.y + "FT";
        }
    }

    void SetVaribles()
    {
        texture = GameObject.Find("Camera Goal Line Image").GetComponent<Image>();
        textureObj = GameObject.Find("Camera Goal Line Image");
        this.transform.position = new Vector2(0, lineheight);

        textObj = GameObject.Find("Camera Goal Text");
        text = textObj.GetComponent<TextMesh>();

        mainCamera = GameObject.Find("Main Camera");
        camcontroller = mainCamera.GetComponent<CameraController>();
    }
    void HideLine()
    {
        if (showLine == false)
        {
            text.GetComponent<MeshRenderer>().enabled = false;
            textureObj.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (showLine == true)
        {
            text.GetComponent<MeshRenderer>().enabled = true;
            textureObj.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
