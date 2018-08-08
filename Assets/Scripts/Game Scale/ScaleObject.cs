using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField]
    public float XScailFactor;
    [SerializeField]
    public float yScailFactor;
    [HideInInspector]
    private float width;
    [SerializeField]
    private bool isObject = true;
    [SerializeField]
    private bool checkWidth = false;
    [SerializeField]
    private bool UpdateSize = true;

    private void Awake()
    {
        StartSequence();
    }

    private void OnPreRender()
    {
        StartSequence();
    }

    private void Update()
    {
        if (UpdateSize == true)
        {
            StartSequence();
        }
        
    }

    void StartSequence()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;

        if (isObject == true)
        {
            if (isObject == true)
            {
                mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
                updateScreenVaribles();
            }

        }
        else
        {
            width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;
        }
    }

    void updateScreenVaribles()
    {
        if (checkWidth == true)
        {
            if (width >= 10)
            {
                width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;
                GameData.ScreenWidth = width;

                transform.localScale = new Vector2(width * XScailFactor, this.transform.localScale.y);
                transform.localScale = new Vector2(this.transform.localScale.x, width * yScailFactor);

            }
            else
            {
                width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;
                GameData.ScreenWidth = width;

                transform.localScale = new Vector2(width * XScailFactor*2 , this.transform.localScale.y);
                transform.localScale = new Vector2(this.transform.localScale.x, width * yScailFactor*2 );
            }
        }
        else
        {
            width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;
            GameData.ScreenWidth = width;

            transform.localScale = new Vector2(width * XScailFactor, this.transform.localScale.y);
            transform.localScale = new Vector2(this.transform.localScale.x, width * yScailFactor);
        }
       
        
    }
}
