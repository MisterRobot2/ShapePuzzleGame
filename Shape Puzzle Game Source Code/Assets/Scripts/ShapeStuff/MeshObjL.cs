using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshObjL : MonoBehaviour
{

    public Vector3[] vertices = new Vector3[8];

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void meshCreatorL()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;


        //Vertices
        int widthL = Random.Range(2, 5);
        int widthS = Random.Range(1, widthL - 1);
        int heightL = Random.Range(2, 5);
        int heightS = Random.Range(1, heightL - 1);


        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, heightS, 0);
        vertices[2] = new Vector3(0, heightL, 0);
        vertices[3] = new Vector3(widthS, heightL, 0);
        vertices[4] = new Vector3(widthS, heightS, 0);
        vertices[5] = new Vector3(widthL, heightS, 0);
        vertices[6] = new Vector3(widthL, 0, 0);
        vertices[7] = new Vector3(widthS, 0, 0);

        //foreach(var point in vertices)
        //{
        //    Debug.Log(point);
        //}

        //Triangles

        int[] tri = new int[12];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 3;

        tri[3] = 0;
        tri[4] = 3;
        tri[5] = 7;

        tri[6] = 7;
        tri[7] = 5;
        tri[8] = 6;

        tri[9] = 7;
        tri[10] = 4;
        tri[11] = 5;


        //Assign Arrays

        mesh.vertices = vertices;
        mesh.triangles = tri;

        int[] angles = new int[4] { 0, 90, 180, 270 };


        transform.RotateAround(gameObject.GetComponent<Renderer>().bounds.center, Vector3.forward, angles[Random.Range(0, 4)]);


        //COLOR
        Renderer rend = GetComponent<Renderer>();


        if (GameData.currentTeamNumber == 1)
        {
            rend.material.shader = Shader.Find("Unlit/Color");
            rend.material.SetColor("Main Color", GameData.team2Color);
        }
        if (GameData.currentTeamNumber == 2)
        {
            rend.material.shader = Shader.Find("Unlit/Color");
            rend.material.SetColor("Main Color", GameData.team1Color);
        }
        /*
        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.green);
        */


    }
}