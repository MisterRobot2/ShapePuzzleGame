using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScailOBject : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField]
    public float XScailFactor;
    [SerializeField]
    public float yScailFactor;
    [HideInInspector]
    public double width;
    [HideInInspector]
    public float floatWidth;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        updateScreenVaribles();

    }
	// Update is called once per frame
	void Update () {
        updateScreenVaribles();

    }

    void updateScreenVaribles()
    {
        width = mainCamera.orthographicSize * 2.0 * Screen.width / Screen.height;
        float floatWidth = (float)width;
        transform.localScale = new Vector2(floatWidth * XScailFactor, this.transform.localScale.y);
        transform.localScale = new Vector2(this.transform.localScale.x, floatWidth * yScailFactor);

        Debug.Log(floatWidth + "tootdle");
    }
}
