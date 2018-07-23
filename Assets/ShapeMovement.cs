using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour
{

    public GameObject shape;
    private Rigidbody2D rb;
    private Vector3 v;
    [SerializeField]
    [Range(0,20)]
    private int movementSpeed = 20;

    void Start()
    {
        rb = shape.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Translate(new Vector3(-movementSpeed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Translate(new Vector3(movementSpeed, 0, 0));

        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = 25;
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 0));
        }
        

    }
}
