using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeMovement : MonoBehaviour
{
    public bool isFrozen;
    public GameObject shape;
    private Rigidbody2D rb;
    [SerializeField]
    [Range(0,20)]
    private int movementSpeed = 20;
    public bool canBeControlled = true;
    private bool hasSpawn = false;
    private bool hasCollided;
    private AudioSource blockLanding;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        hasCollided = false;
        blockLanding = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canBeControlled == true && DataBase.isPlayerPlaying)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0),Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0), Space.World);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.gravityScale = 2;
                canBeControlled = false;
                DataBase.score++;
                StartCoroutine(Freeze());
            }
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasCollided == false)
        {
            blockLanding.Play();
            hasCollided = true;
        }
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(5);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        isFrozen = true;
    }
}
