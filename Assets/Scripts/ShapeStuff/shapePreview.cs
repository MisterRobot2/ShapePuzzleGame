﻿using System.Collections.Generic;
using UnityEngine;

public class shapePreview : MonoBehaviour {


    public GameObject[] shapes = new GameObject[] { };
    public List<GameObject> createdShapes = new List<GameObject>();

    private Camera previewCamera;
    private GameObject nextShape;
    private GameObject objectToSpawn;

    public MeshCreator MeshObjL;

    private void Start()
    {
        previewCamera = this.gameObject.transform.parent.gameObject.GetComponent<Camera>();
       
    }

    public void SpawnFirstShape()
    {
        
        //Creates Preview
        nextShape = GameObject.Instantiate(shapes[Random.Range(0, shapes.Length)]);
        nextShape.transform.position = this.gameObject.transform.position;
        //Get Mesh Creator
        if (nextShape.GetComponent<MeshCreator>() == true)
        {
            nextShape.GetComponent<MeshCreator>().meshCreator();
        }
        else if (nextShape.GetComponent<MeshObjL>() == true)
        {
            nextShape.GetComponent<MeshObjL>().meshCreatorL();
        }
    }

    public void calculatePreview()
    {
        //Takes preview and puts it to spawn spot
        GameObject newObject = nextShape;
        newObject.transform.position = GameObject.FindGameObjectWithTag("Spawner").transform.position;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = true;
        

        if (newObject.GetComponent<SpriteRenderer>())
        {

            if (DataBase.currentTeamNumber == 1)
            {
                newObject.GetComponent<SpriteRenderer>().color = DataBase.team1Color;
            }
            else if (DataBase.currentTeamNumber == 2)
            {
                newObject.GetComponent<SpriteRenderer>().color = DataBase.team2Color;
            }
        }
        else if (newObject.GetComponent<MeshRenderer>())
        {
            if (DataBase.currentTeamNumber == 1)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", DataBase.team1Color);
            }
            else if (DataBase.currentTeamNumber == 2)
            {
                newObject.GetComponent<MeshRenderer>().material.SetColor("_Color", DataBase.team1Color);
            }
        }

        //Add gravity
        newObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        //Add Colliders
        if(nextShape.GetComponent<MeshCreator>() == true){
            newObject.AddComponent<BoxCollider2D>();
        }else if (nextShape.GetComponent<MeshObjL>() == true){
            newObject.AddComponent<PolygonCollider2D>();
            Vector3[] temp = new Vector3[8];
            temp = newObject.GetComponent<MeshObjL>().vertices;
            Vector2[] vertices2 = new Vector2[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                Vector3 tempV3 = temp[i];
                vertices2[i] = new Vector2(tempV3.x, tempV3.y);
            }
            vertices2 [temp.Length] = new Vector2(temp[0].x, temp[0].y);

            newObject.GetComponent<PolygonCollider2D>().SetPath(0, vertices2);
        }



                 
        
        //Make new Preview
        nextShape = GameObject.Instantiate(shapes[Random.Range(0, shapes.Length)], this.gameObject.transform);
        nextShape.transform.position = this.gameObject.transform.position;
        nextShape.GetComponent<ShapeMovement>().canBeControlled = false;
        //Get Mesh Creator
        if (nextShape.GetComponent<MeshCreator>() == true)
        {
            nextShape.GetComponent<MeshCreator>().meshCreator();
        }
        else if (nextShape.GetComponent<MeshObjL>() == true)
        {
            nextShape.GetComponent<MeshObjL>().meshCreatorL();
        }

    }

  

}
