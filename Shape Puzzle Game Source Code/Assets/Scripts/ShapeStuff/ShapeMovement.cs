using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShapeMovement : MonoBehaviour
{
    public bool isFrozen;
    public GameObject shape;
    public bool canBeControlled = true;
    public Rigidbody2D rb;

    [SerializeField]
    [Range(0, 20)]
    public float movementSpeed = CurrentData.gameData.blockSpeed;

    private bool hasSpawn = false;
    private bool hasCollided;
    private AudioSource blockLanding;
    private GameController gamecontroller;
    [Tooltip("Put it in if it has it ")]
    public BoxCollider2D boxCollider2D;
    [Tooltip("Put it in if it has it ")]
    public PolygonCollider2D polycollider2D;
    private Camera cam;

    private Vector3 oldPosition;
    private Quaternion oldRotation;

    void Start()
    {
        gamecontroller = GameObject.Find("Game Controller").gameObject.GetComponent<GameController>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        hasCollided = false;
        blockLanding = this.GetComponent<AudioSource>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        RemoveColliders();
    }

    private void FixedUpdate()
    {
        oldPosition = this.transform.position;
        oldRotation = this.transform.rotation;
    }

    void Update()
    {

        RemoveColliders();
        destoryBlockOnGameOver();
        //Changes game speed with diffrent screen reslutions
        if (GameData.ScreenWidth >= 10)
        {
            movementSpeed = CurrentData.gameData.blockSpeed;
        }
        else
        {
            movementSpeed = CurrentData.gameData.blockSpeed / 2;
        }

        // Fixes the Block From Disspearing
        if (canBeControlled == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
        }

        // slows block down 
        if (canBeControlled == true && GameData.isPlayerPlaying)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                GameData.oldSpeed = movementSpeed;
                CurrentData.gameData.blockSpeed = movementSpeed / 2;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                CurrentData.gameData.blockSpeed = GameData.oldSpeed;
                if (GameData.firstSkip == true)
                {
                    GameData.firstSlowDown = true;
                }
            }

            //Block Controlls
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0), Space.World);
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -9, 9), this.transform.position.y, this.transform.position.z);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0), Space.World);
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -9, 9), this.transform.position.y, this.transform.position.z);
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && GameData.canSpawnShape == true)
            {
                GameData.blockIsFalling = true;

                //rb.gravityScale = 2;
                DropBlock();
            }


            //Touch Input
            if (Input.touchCount > 0)
            {
                Touch touchZero = Input.GetTouch(0);
                if (Input.touchCount == 1 && GameData.canTouchMoveBlock == true)
                {
                    if (touchZero.phase == TouchPhase.Began || touchZero.phase == TouchPhase.Moved || touchZero.phase == TouchPhase.Stationary)
                    {
                        this.transform.position = new Vector3(cam.ScreenToWorldPoint(touchZero.position).x, this.transform.position.y, this.transform.position.z);
                    }

                    if ((touchZero.phase == TouchPhase.Canceled || touchZero.phase == TouchPhase.Ended) && GameData.canTouchMoveBlock == true)
                    {
                        DropBlock();
                    }
                }
            }

            //Touch Debug  
            /*
            if (Input.mousePresent == true)
            {
                if (Input.GetMouseButton(0) && GameData.canTouchMoveBlock == true)
                {
                    this.transform.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, this.transform.position.y, this.transform.position.z);
                }
                if (Input.GetMouseButtonUp(0) && GameData.canTouchMoveBlock == true)
                {
                    DropBlock(); 
                }
            } */
        }
        else
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 0));
        }

        PlaceBlockFollowSpawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided == false)
        {
            StartCoroutine(Freeze());
            blockLanding.Play();
            GameData.blocksPlacedInGame++;
            GameData.firstDrop = true;
            GameData.blockIsFalling = false;
            hasCollided = true;
        }
    }

    //Drops the block
    void DropBlock()
    {
        if (GameData.ScreenWidth >= 10)
        {
            rb.gravityScale = 2;
        }
        else
        {
            rb.gravityScale = 1;
        }

        canBeControlled = false;
        StartCoroutine(Freeze());
        rb.constraints = RigidbodyConstraints2D.None;

        if (polycollider2D != null)
        {
            polycollider2D.enabled = true;
        }

        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = true;
        }

        gamecontroller.SpawnNewBlock();
    }

    // Freeze block after so mutch seconds
    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(.1f);
        if (GameData.isGameOver == false && oldPosition == this.transform.position && oldRotation == this.transform.rotation)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isFrozen = true;
        }
        else
        {
            StartCoroutine(Freeze());
        }
    }

    //Bug Fixes 
    void PlaceBlockFollowSpawn()
    {
        if (GameData.canSpawnShape == false)
        {
            if (canBeControlled == true)
            {
                GameObject spawner = GameObject.Find("Spawner");
                this.transform.position = new Vector3(this.transform.position.x, spawner.transform.position.y, -1);
            }

        }
    }

    // Destroys block when its game over
    void destoryBlockOnGameOver()
    {
        if (GameData.isGameOver == true && canBeControlled == true)
        {
            Destroy(this.gameObject);
        }
    }

    //Removes the colliders when block is being controlled
    public void RemoveColliders()
    {
        if (canBeControlled == true)
        {
            if (polycollider2D != null)
            {
                polycollider2D.enabled = false;
            }

            if (boxCollider2D != null)
            {
                boxCollider2D.enabled = false;
            }
        }

    }
}
