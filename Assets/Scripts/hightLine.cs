using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hightLine : MonoBehaviour
{
    [SerializeField]
    private float upSpeed = 0.1f;

    private GameObject topblock = null;
    private bool isColliding = true;
    private bool Freeze;
    private bool upSequence;
    private bool downSequence;
    
	void Start ()
    {
        upSequence = true;
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
            Debug.Log(topblock == collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (topblock == other.gameObject)
        {
            Freeze = true;
            Debug.Log(topblock == other.gameObject);
        }
        else
        {
            Freeze = false;
        }
        upSequence = true;
    }
}
