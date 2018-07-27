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
    void Start()
    {
        if (parent == null)
        {
            parent = GameObject.Instantiate(new GameObject(), this.transform);
            parent = GameObject.Find("New Game Object");
            parent.name = "ShapeHolder";
        }
        shapePreview = GameObject.FindGameObjectWithTag("ShapePreview");
        DataBase.currentTeamNumber = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    //public List<GameObject> createdShapes2 = List<GameObject> GetComponent<shapePreview>().createdShapes;
    //shapePreview s1;

    /*public void ShapeSpawner()
    {

        // s1 = GetComponent<shapePreview>();


        //Debug.Log(s1.createdShapes[0]);

        //createdShapes2.Clear();

        //for (int i = 0; i < GetComponent<shapePreview>().createdShapes.Count; i++)
        //{
        //    createdShapes2.Add(GetComponent<shapePreview>().createdShapes[i]);
        //}


        //if (createdShapes2.Count >= 2)
        //{
        //    GameObject currentShape = createdShapes2[createdShapes2.Count - 2];
        //    currentShape.transform.position = this.gameObject.transform.position;
        //}

        //GameObject currentShape = s1.createdShapes[0];
        //currentShape.transform.position = this.gameObject.transform.position;
    }*/

    public void SpawnShape()
    {
        if (DataBase.currentTeamNumber != 0)
        {
            shapePreview.GetComponent<shapePreview>().calculatePreview();
        }
    }
}