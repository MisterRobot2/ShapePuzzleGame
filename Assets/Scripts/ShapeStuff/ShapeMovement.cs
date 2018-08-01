using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeMovement : MonoBehaviour
{
    public bool isFrozen;
    public GameObject shape;
    public bool canBeControlled = true;
    public Rigidbody2D rb;

    [SerializeField]
    [Range(0, 20)]
    public float movementSpeed = DataBase.speed;
    
    
    private bool hasSpawn = false;
    private bool hasCollided;
    private AudioSource blockLanding;
    private GameController gamecontroller;

    void Start()
    {
        gamecontroller = GameObject.Find("Game Controller").gameObject.GetComponent<GameController>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        hasCollided = false;
        blockLanding = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        movementSpeed = DataBase.speed;

        if (canBeControlled == true && DataBase.isPlayerPlaying)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0),Space.World);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0), Space.World);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.DownArrow))
            {
                rb.gravityScale = 2;
                canBeControlled = false;
                StartCoroutine(Freeze());
                rb.constraints = RigidbodyConstraints2D.None;
                gamecontroller.SpawnNewBlock();
            }
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 0));
        }

        PlaceBlockFollowSpawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasCollided == false)
        {
            blockLanding.Play();
            DataBase.blocksPlacedInGame++;
            hasCollided = true;
        }
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(3);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        isFrozen = true;
    }

    void PlaceBlockFollowSpawn()
    {
        if (DataBase.canSpawnShape == false)
        {
            if (canBeControlled == true)
            {
                GameObject spawner = GameObject.Find("Spawner");
                this.transform.position = new Vector2(this.transform.position.x, spawner.transform.position.y);
            }
            
        }
    }
}
