using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshObjL : MonoBehaviour
{


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


        Vector3[] vertices = new Vector3[8]
        {
            new Vector3(0,0,0), new Vector3(0,heightS,0), new Vector3(0,heightL,0), new Vector3(widthS,heightL,0), new Vector3(widthS,heightS,0), new Vector3(widthL, heightS, 0), new Vector3(widthL, 0, 0), new Vector3(widthS,0,0)

        };


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

        // transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angles[Random.Range(0, 4)]));


        transform.RotateAround(gameObject.GetComponent<Renderer>().bounds.center, Vector3.forward, angles[Random.Range(0, 4)]);


        //COLOR
        Renderer rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

        //Find the Specular shader and change its Color
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.green);


    }
}