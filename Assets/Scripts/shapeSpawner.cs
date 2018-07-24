using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeSpawner : MonoBehaviour
{

    public GameObject[] shapes = new GameObject[]{};

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShapeSpawner() {

        GameObject newObject = GameObject.Instantiate(shapes[Random.Range(0, shapes.Length)], this.gameObject.transform);
        newObject.transform.position = this.gameObject.transform.position;
    }
}

