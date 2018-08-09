//NOT BEING USED



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeSpawner : MonoBehaviour
{
    public GameObject[] shapes = new GameObject[] { };
    public GameObject parent;
    private GameObject shapePreview;

    // Use this for initialization
    void Awake()
    {
        if (parent == null)
        {
            parent = GameObject.Instantiate(new GameObject(), this.transform);
            parent = GameObject.Find("New Game Object");
            parent.name = "ShapeHolder";
        }
        shapePreview = GameObject.FindGameObjectWithTag("ShapePreview");
        GameData.currentTeamNumber = 1;
    }

    //Spawn Shapes
    public void SpawnShape()
    {
        if (GameData.currentTeamNumber != 0)
        {
            shapePreview.GetComponent<shapePreview>().calculatePreview(false);
        }
    }
}