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
    public float width;

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
        width = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;

        transform.localScale = new Vector2(width * XScailFactor, this.transform.localScale.y);
        transform.localScale = new Vector2(this.transform.localScale.x, width * yScailFactor);

    }
}
