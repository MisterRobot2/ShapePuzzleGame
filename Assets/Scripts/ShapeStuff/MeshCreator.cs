using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    

    //public float width = 1;
    //public float height = 1;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {



    }

   public Vector3[] vertices = new Vector3[4];




    public void meshCreator(){
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;


        //Vertices
        int width = Random.Range(1, 5);
        int height = Random.Range(1, 5);



        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, height, 0);
        vertices[2] = new Vector3(width, height, 0);
        vertices[3] = new Vector3(width, 0, 0);





        //Triangles

        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 1;
        tri[2] = 2;

        tri[3] = 0;
        tri[4] = 2;
        tri[5] = 3;



        //Assign Arrays

        mesh.vertices = vertices;
        mesh.triangles = tri;


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
