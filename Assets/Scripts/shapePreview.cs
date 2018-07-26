using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapePreview : MonoBehaviour {


    public GameObject[] shapes = new GameObject[] { };

    public List<GameObject> createdShapes = new List<GameObject>();




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
    }

  

}
