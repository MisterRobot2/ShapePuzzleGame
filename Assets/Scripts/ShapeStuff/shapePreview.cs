using System.Collections.Generic;
using UnityEngine;

public class shapePreview : MonoBehaviour {


    public GameObject[] shapes = new GameObject[] { };
    public List<GameObject> createdShapes = new List<GameObject>();

<<<<<<< HEAD
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

=======
    private Camera previewCamera;
    private GameObject nextShape;
    private GameObject objectToSpawn;
>>>>>>> 32dcf72e678504133d0c2d9a52d391d11d14df3a

    private void Start()
    {
<<<<<<< HEAD
        GameObject newObject = GameObject.Instantiate(shapes[Random.Range(0, shapes.Length)], this.gameObject.transform);
        newObject.transform.position = this.gameObject.transform.position;


=======
        previewCamera = this.gameObject.transform.parent.gameObject.GetComponent<Camera>();
       
    }
>>>>>>> 32dcf72e678504133d0c2d9a52d391d11d14df3a

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

<<<<<<< HEAD
       

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

=======
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
>>>>>>> 32dcf72e678504133d0c2d9a52d391d11d14df3a

    }


  

}
