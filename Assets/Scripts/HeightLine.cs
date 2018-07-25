using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightLine : MonoBehaviour
{
    [SerializeField]
    private float upSpeed = 0.1f;
    [SerializeField]
    private float Height;
    [SerializeField]
    private TextMesh text;
    private float initalHeight;

    private GameObject topblock = null;
    private bool isColliding = true;
    private bool Freeze;
    private bool upSequence;
    private bool downSequence;
    
	void Start ()
    {
        upSequence = true;
        initalHeight = this.transform.position.y;
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

        CalculateHeight();
	}

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

    void CalculateHeight()
    {
        Height = (Mathf.Round((this.transform.position.y - initalHeight)*10))/10;
        text.text = Height + "Ft";
    }
}
