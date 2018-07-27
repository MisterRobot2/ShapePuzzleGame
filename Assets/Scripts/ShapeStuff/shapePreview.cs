using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapePreview : MonoBehaviour {


    public GameObject[] shapes = new GameObject[] { };

    public List<GameObject> createdShapes = new List<GameObject>();

    public Camera pcam;

    private GameObject newestObject;

   
    //----------EDGE COLLIDER----------------------

    public MeshCreator MeshCreator;



    //----------END EDGE COLLIDER----------------------



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


    public void ShapePreview()
    {
        GameObject newObject = GameObject.Instantiate(shapes[Random.Range(0, shapes.Length)], this.gameObject.transform);
        newObject.transform.position = this.gameObject.transform.position;



        if(newObject.GetComponent<MeshCreator>() == true){
            newObject.GetComponent<MeshCreator>().meshCreator();
        } else if(newObject.GetComponent<MeshObjL>() == true){
            newObject.GetComponent<MeshObjL>().meshCreatorL();
        }

       

        createdShapes.Add(newObject);

        GameObject newObject2 = GameObject.Instantiate(createdShapes[createdShapes.Count-2]);
        newObject2.transform.position = new Vector3(0,0,0);
        newObject2.GetComponent<Rigidbody2D>().gravityScale = 1;


        Destroy(createdShapes[createdShapes.Count - 2]);


        ////----------EDGE COLLIDER----------------------
        //if (newObject2.GetComponent<MeshCreator>() == true)
        //{
        //    newObject2.AddComponent<EdgeCollider2D>();


        //    //newObject2.GetComponent<EdgeCollider2D>().points = GetComponent<MeshCreator>.;

        //    Vector3[] temp = new Vector3[4];
        //    temp = newObject2.GetComponent<MeshCreator>().vertices;

        //    foreach (var point in temp)
        //    {
        //        Debug.Log(point);
        //        Debug.Log(temp.Length);
        //    }

        //    Vector2[] temp2 = new Vector2[temp.Length+1];
        //    for (int i = 0; i < temp.Length; i++)
        //    {
        //        Vector3 tempV3 = temp[i];
        //        temp2[i] = new Vector2(tempV3.x, tempV3.y);
        //    }

        //   temp2[temp.Length] = new Vector2(temp[0].x, temp[0].y);

        //    newObject2.GetComponent<EdgeCollider2D>().points = temp2;
        //}
       

        ////---------END EDGE COLLIDER-----------------------

        if (newObject2.GetComponent<MeshCreator>() == true){
            newObject2.AddComponent<BoxCollider2D>();
        } else{
            newObject2.AddComponent<PolygonCollider2D>();

        }


    }


  

}
