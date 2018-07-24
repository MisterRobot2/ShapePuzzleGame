using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float width = 50f;
    public float height = 50f;

	// Use this for initialization
	void Start () {

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;


        //Vertices
        Vector3[] vertices = new Vector3[4]{
            new Vector3(0,0,0), new Vector3(width,0,0), new Vector3(0,height,0), new Vector3(width, height, 0)
        };

        //Triangles

        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;



        //Normals
        Vector3[] normals = new Vector3[4];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;


        //Assign Arrays

        mesh.vertices = vertices;
        mesh.triangles = tri;
        mesh.normals = normals;

	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
