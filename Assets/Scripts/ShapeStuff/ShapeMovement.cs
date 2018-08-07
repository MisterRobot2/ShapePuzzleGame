﻿using System.Collections;
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
    public float movementSpeed = CurrentData.gameData.speed;
    
    
    private bool hasSpawn = false;
    private bool hasCollided;
    private AudioSource blockLanding;
    private GameController gamecontroller;
    [Tooltip("Put it in if it has it ")]
    public BoxCollider2D boxCollider;
    [Tooltip("Put it in if it has it ")]
    public PolygonCollider2D polycollider2D;

    void Start()
    {
        gamecontroller = GameObject.Find("Game Controller").gameObject.GetComponent<GameController>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        hasCollided = false;
        blockLanding = this.GetComponent<AudioSource>();

        RemoveColliders();
    }

    void Update()
    {
        if (DataBase.ScreenWidth >= 10)
        {
            movementSpeed = CurrentData.gameData.speed;
        }
        else
        {
            movementSpeed = CurrentData.gameData.speed/2;
        }
        
        
        if (canBeControlled == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);

            if (DataBase.isGameOver == true)
            {
                Destroy(this.gameObject);
            }
        }
        
        // slows block down 
        if (canBeControlled == true && GameData.isPlayerPlaying)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                GameData.oldSpeed = movementSpeed;
                CurrentData.gameData.speed = movementSpeed / 2;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                CurrentData.gameData.speed = GameData.oldSpeed;
                if (GameData.firstSkip == true)
                {
                    GameData.firstSlowDown = true;
                }
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0),Space.World);
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -9, 9),this.transform.position.y, this.transform.position.z);
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
                //rb.gravityScale = 2;

                if (DataBase.ScreenWidth >= 10)
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
                else if (boxCollider != null)
                {
                    boxCollider.enabled = true;
                }

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
            GameData.blocksPlacedInGame++;
            GameData.firstDrop = true;
            hasCollided = true;
        }
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(3);
        if (DataBase.isGameOver == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isFrozen = true;
        }
        
    }

    void PlaceBlockFollowSpawn()
    {
        if (GameData.canSpawnShape == false)
        {
            if (canBeControlled == true)
            {
                GameObject spawner = GameObject.Find("Spawner");
                this.transform.position = new Vector3(this.transform.position.x, spawner.transform.position.y,-1);
            }
            
        }
    }

    void destoryBlockOnGameOver()
    {
        if (GameData.isGameOver == true && canBeControlled == true)
        {
            Destroy(this.gameObject);

        }
    }

    public void RemoveColliders()
    {
        if (polycollider2D != null)
        {
            polycollider2D.enabled = false;
        }
        else if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }
}
